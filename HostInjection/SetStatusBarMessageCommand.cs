using System.Management.Automation;

namespace PowerShellToolsPro.Cmdlets.VSCode
{
    /// <summary>
    /// Cmdlet to set a status bar message in Visual Studio Code.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "VSCodeStatusBarMessage")]
    public class SetStatusBarMessageCommand : VSCodeCmdlet
    {
        /// <summary>
        /// The text to send to the status bar.
        /// </summary>
        [Parameter(Mandatory = true)]
        public string Message { get; set; }

        /// <summary>
        /// How long the status bar message should display in milliseconds. Defaults to 5000 ms.
        /// </summary>
        [Parameter()]
        public int Timeout { get; set; } = 5000;

        protected override void BeginProcessing()
        {
            var result = SendCommand($"vscode.window.setStatusBarMessage", new { message = Message, hideAfterTimeout = Timeout });

            if (result != null)
                WriteObject(result);
        }
    }
}
