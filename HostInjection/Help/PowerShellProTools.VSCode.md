---
Module Name: PowerShellProTools.VSCode
Module Guid: 6445e5c3-d794-4af8-82a4-7ee94e0d4f1b
Download Help Link: {{ Update Download Link }}
Help Version: {{ Please enter version of help manually (X.X.X.X) format }}
Locale: en-US
---

# PowerShellProTools.VSCode Module
## Description
This module contains cmdlets primarily for interacting with the VSCode extension.
Some interact with text and decorations in the editor, some are used by extension commands such as
`Start-PoshToolsServer` or `Measure-Script`, and others offer extra interaction with VSCode not available to the
standard PowerShell extension (e.g. `Show-VSCodeInputBox`).

## PowerShellProTools.VSCode Cmdlets
### [Add-VSCodeTextDocumentText](Add-VSCodeTextDocumentText.md)
Inserts text into a particular position in the selected document. This creates an edit but does not save the file.

### [Clear-VSCodeDecoration](Clear-VSCodeDecoration.md)
Clear decorations created by Set-VSCodeTextEditorDecoration.

### [Get-CompletionItem](Get-CompletionItem.md)
TODO

### [Get-PoshToolsVariable](Get-PoshToolsVariable.md)
TODO

### [Get-VSCodeTerminal](Get-VSCodeTerminal.md)
Retrieves a list of open terminals.

### [Get-VSCodeTextDocument](Get-VSCodeTextDocument.md)
Returns a list of currently open documents.

### [Get-VSCodeTextDocumentText](Get-VSCodeTextDocumentText.md)
Gets the text of a document.

### [Get-VSCodeTextEditor](Get-VSCodeTextEditor.md)
Retrieves the currently visible text editor.

### [Measure-Block](Measure-Block.md)
TODO

### [Measure-Script](Measure-Script.md)
TODO

### [New-VSCodeDecorationAttachment](New-VSCodeDecorationAttachment.md)
TODO

### [New-VSCodePosition](New-VSCodePosition.md)
Returns a position in a given document.

### [New-VSCodeRange](New-VSCodeRange.md)
Returns a range between start and end positions.

### [New-VSCodeTreeItem](New-VSCodeTreeItem.md)
Creates a child tree item under a custom TreeView.

### [Open-VSCodeTextDocument](Open-VSCodeTextDocument.md)
Opens documents by file name.

### [Out-PoshToolsVariable](Out-PoshToolsVariable.md)
TODO

### [Out-VSCodeGridView](Out-VSCodeGridView.md)
Displays data in a grid view similar to Out-GridView, except in a VS Code web view.

### [Register-VSCodeTreeView](Register-VSCodeTreeView.md)
Creates a TreeView entry in the Custom view.

### [Remove-VSCodeTextDocumentText](Remove-VSCodeTextDocumentText.md)
Removes a range of text from a document.

### [Remove-VSCodeTextEditor](Remove-VSCodeTextEditor.md)
Close editors that are already open.

### [Send-VSCodeTerminalText](Send-VSCodeTerminalText.md)
Sends text to the specified terminal.

### [Set-VSCodeStatusBarMessage](Set-VSCodeStatusBarMessage.md)
Sets a status bar message.

### [Set-VSCodeTextEditorDecoration](Set-VSCodeTextEditorDecoration.md)
Decorates a range of text with an optional set of colors, outlines, borders, and text.

### [Show-VSCodeInputBox](Show-VSCodeInputBox.md)
Shows an input box for the user to enter arbitrary text.

### [Show-VSCodeMessage](Show-VSCodeMessage.md)
Show a message to the user and provide an option for them to select.

### [Show-VSCodeQuickPick](Show-VSCodeQuickPick.md)
Shows a quick pick list for a user to select items from.

### [Start-PoshToolsServer](Start-PoshToolsServer.md)
Starts the main PoshTools Server for the extension to connect to.

