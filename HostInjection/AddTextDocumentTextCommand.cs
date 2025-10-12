using System.IO;
using System.Management.Automation;
using Newtonsoft.Json;

namespace PowerShellToolsPro.Cmdlets.VSCode
{
    /// <summary>
    /// Cmdlet to add text to a specified position in a VSCode text document.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "VSCodeTextDocumentText")]
    public class AddTextDocumentTextCommand : VSCodeCmdlet
    {
        /// <summary>
        /// The VSCode text document where the text will be added.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public VsCodeTextDocument TextDocument { get; set; }

        /// <summary>
        /// The position in the text document where the text will be inserted.
        /// </summary>
        [Parameter(Mandatory = true)]
        public VsCodePosition Position { get; set; }

        /// <summary>
        /// The text to be inserted into the document.
        /// </summary>
        [Parameter(Mandatory = true)]
        public string Text { get; set; }

        protected override void ProcessRecord()
        {
            Wait = SwitchParameter.Present;
            
            var result = SendCommand($"vscode.TextDocument.insert", new { fileName = TextDocument.FileName, position = Position, text = Text });
            WriteObject(result);
        }
    }
}
