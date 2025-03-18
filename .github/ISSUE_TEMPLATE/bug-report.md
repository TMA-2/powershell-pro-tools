---
name: Bug report
about: Create a report to help us improve
title: VSCode Extension - Feature X isn't working
labels: bug
assignees: ''

---

## Description
A clear and concise description of what the bug is.

## Expected behavior
A clear and concise description of what you expected to happen.

## Actual behavior
A clear and concise description of what actually happens that differs from [expected behavior](#expected-behavior).

## Reproduction
Steps to reproduce the [behavior](#expected-behavior) that results in [the above](#actual-behavior):
1. Go to '...'
2. Click on '....'
3. Scroll down to '....'
4. See error

## Versions
### OS
- e.g. *Windows 11 23H2*
### Program [e.g. VSCode, Visual Studio 2022]
- VS Code version: e.g. 1.97.2
  - Run `code --version`, or...
  - Copy from `Help > About`
- Visual Studio 2022 version: e.g. 17.12.4
  - Run `"${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" -property catalog_productDisplayVersion`, or...
  - Copy from `Help > About Microsoft Visual Studio`
### PowerShell
- e.g. 7.5.0
  - Run `$PSVersionTable.PSVersion` in PowerShell
### PowerShell VSCode Extension (if applicable)
- Find by running: `code --list-extensions --show-versions | select-string ms-vscode.powershell`
### PowerShell Pro Tools Extension Details
- Name: e.g. PowerShell Pro Tools VSCode, PowerShell Pro Tools VS 2019, etc.
- Version: e.g. `2024.12.0`
#### VSCode Extension Version
- Find by running: `code --list-extensions --show-versions | select-string powershellprotools`, or...
- View > Extensions > Find PowerShell Pro Tools > Right-click > Copy
#### Visual Studio Extension Version
- Find by running: (if there's an easier way to find and list VS extensions, I'm all ears...)
```ps1
$VSCatalog = gci "$env:ProgramFiles\Microsoft Visual Studio\20[0-9]*\Community\Common7\IDE\Extensions\*","$env:LOCALAPPDATA\Microsoft\VisualStudio\1[0-9].0_*\Extensions\*" -Directory | gci -File -Filter 'powershelltools.*.pkgdef' -Recurse -Depth 1 | %{Split-Path $_.FullName -Parent | Join-Path -ChildPath 'catalog.json'}
if($VSCatalog) {
  (gc $VSCatalog | ConvertFrom-Json).packages | select id,version
}
```
- Or: `Extensions > Manage Extensions > Installed > Find "PowerShell Tools for Visual Studio"`

## Screenshots
If applicable, add screenshots to help explain your problem.

## Additional context
If applicable, add any other context about the problem here, related applications or versions, log content from the VS Code Output view, etc.
