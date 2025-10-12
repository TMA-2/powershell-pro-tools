'use strict';
import * as vscode from 'vscode';
import { ICommand } from './command';
import { Container } from '../container';
import { QuickScript, QuickScriptViewProvider } from '../treeView/quickScriptView';

export class QuickScriptCommands implements ICommand {
    register(context: vscode.ExtensionContext) {
        context.subscriptions.push(this.addQuickScript());
        context.subscriptions.push(this.openQuickScript());
        context.subscriptions.push(this.removeQuickScript());
    }

    addQuickScript() {
        return vscode.commands.registerCommand('poshProTools.addQuickScript', async () => {
            if (!Container.IsInitialized()) return;

            let filePath: string | undefined;
            let workspacePath = vscode.workspace.workspaceFolders?.[0].uri;
            const editor = vscode.window.activeTextEditor;

            if (editor) {
                filePath = editor.document.fileName;
            }
            else if (workspacePath) {
                vscode.window.showWarningMessage("No active editor file. Please select a file to add as a Quick Script.");
                const files = await vscode.window.showOpenDialog({
                    title: "Select a file to add to Quick Scripts",
                    openLabel: "Add Quick Script",
                    defaultUri: workspacePath,
                    canSelectMany: false,
                    filters: {
                        "PowerShell": ["ps1", "psm1", "psd1"]
                    }
                });

                if (!files || files.length === 0) {
                    return;
                }

                filePath = files[0].fsPath;
            }
            else {
                vscode.window.showErrorMessage("No active editor file nor workspace folder. Please select a file to add as a Quick Script.");
                return;
            }

            var name = await vscode.window.showInputBox({
                prompt: "Please enter the name for this Quick Script",
                // placeHolder: filePath.split("\\").pop().match(/(.+)\.\w+$/)?.[0] || "Quick Script"
            });

            if (!name || name === "") {
                return;
            }

            await Container.QuickScriptService.setScript(name, filePath);

            vscode.window.showInformationMessage(`${name} was added to Quick Scripts`);

            QuickScriptViewProvider.Instance.refresh();
        });
    }

    removeQuickScript() {
        return vscode.commands.registerCommand('poshProTools.removeQuickScript', async (node: QuickScript) => {
            if (!Container.IsInitialized()) return;

            var name = "";
            if (node) {
                name = node.name;
            } else {
                name = await vscode.window.showInputBox({
                    prompt: "Enter the name of the Quick Script to remove"
                })
            }

            if (!name || name === "") return;

            await Container.QuickScriptService.removeScript(name);

            QuickScriptViewProvider.Instance.refresh();

            vscode.window.showInformationMessage(`${name} was removed from Quick Scripts`);
        });
    }

    openQuickScript() {
        return vscode.commands.registerCommand('poshProTools.openQuickScript', async (node: QuickScript) => {
            if (!Container.IsInitialized()) return;

            var name = '"'
            if (node) {
                name = node.name;
            }
            else {
                name = await vscode.window.showInputBox({
                    prompt: "Enter Quick Script name"
                })
            }

            if (!name || name === "") return;

            var script = Container.QuickScriptService.getScript(name);

            if (!script) {
                vscode.window.showErrorMessage(`Quick script ${name} not found`);
                return
            }

            var document = await vscode.workspace.openTextDocument(script.File);
            vscode.window.showTextDocument(document);
        });
    }
}
