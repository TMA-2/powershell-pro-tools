using System;
using System.Management.Automation;

namespace PowerShellToolsPro.Cmdlets.VSCode
{
    /// <summary>
    /// Shows an input box for the user to enter arbitrary text.
    /// </summary>
    /// <example>
    /// <code>
    /// Show-VSCodeInputBox -PlaceHolder 'Enter some text'
    /// </code>
    /// Requests input with the placeholder text 'Enter some text'
    /// </example>
    [Cmdlet(VerbsCommon.Show, "VSCodeInputBox")]
    public class ShowInputBoxCommand : VSCodeCmdlet
    {
        /// <summary>
        /// Don't close the input if it loses focus.
        /// </summary>
        [Parameter()]
        public SwitchParameter IgnoreFocusOut { get; set; }

        /// <summary>
        /// Specifies the input should be masked.
        /// </summary>
        [Parameter()]
        public SwitchParameter Password { get; set; }

        /// <summary>
        /// The default value to fill the input box with.
        /// </summary>
        [Parameter()]
        public string PlaceHolder { get; set; }

        /// <summary>
        /// The user prompt for the input.
        /// </summary>
        [Parameter()]
        public string Prompt { get; set; }

        /// <summary>
        /// The value to fill the input with.
        /// </summary>
        [Parameter()]
        public string Value { get; set; }

        /// <summary>
        /// Start position for value selection. Used with EndValueSelection to create a selection range.
        /// </summary>
        [Parameter()]
        public int StartValueSelection { get; set; }

        /// <summary>
        /// End position for value selection. Used with StartValueSelection to create a selection range.
        /// </summary>
        [Parameter()]
        public int EndValueSelection { get; set; }

        /// <summary>
        /// Processes the input box command and displays the input box to the user.
        /// Returns the user's input as a string.
        /// </summary>
        protected override void BeginProcessing()
        {
            Wait = SwitchParameter.Present;
            var options = new InputBoxOptions();

            if (MyInvocation.BoundParameters.ContainsKey(nameof(Password)))
            {
                options.password = Password.IsPresent;
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(IgnoreFocusOut)))
            {
                options.ignoreFocusOut = IgnoreFocusOut.IsPresent;
            }

            options.value = Value;
            options.prompt = Prompt;
            options.placeHolder = PlaceHolder;

            if (MyInvocation.BoundParameters.ContainsKey(nameof(StartValueSelection)) && MyInvocation.BoundParameters.ContainsKey(nameof(EndValueSelection)))
            {
                options.valueSelection = new Tuple<int, int>(StartValueSelection, EndValueSelection);
            }


            var result = SendCommand($"vscode.window.showInputBox", options);

            if (result != null)
                WriteObject(result);
        }
    }

    /// <summary>
    /// Options for configuring the VS Code input box behavior.
    /// </summary>
    internal class InputBoxOptions
    {
        /// <summary>
        /// Whether to ignore focus out events (don't close the input when it loses focus).
        /// </summary>
        public bool? ignoreFocusOut;

        /// <summary>
        /// Whether the input should be masked (for password input).
        /// </summary>
        public bool? password;

        /// <summary>
        /// The prompt text to display to the user.
        /// </summary>
        public string prompt;

        /// <summary>
        /// The placeholder text to show in the input box.
        /// </summary>
        public string placeHolder;

        /// <summary>
        /// The initial value to populate the input box with.
        /// </summary>
        public string value;

        /// <summary>
        /// A tuple representing the start and end positions for text selection.
        /// </summary>
        public Tuple<int, int> valueSelection;
    }
}
