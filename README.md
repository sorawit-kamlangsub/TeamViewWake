# How to run from ssh
run with run.ps1 script if you see Unhandled exception. FlaUI.Core.Exceptions.MethodNotSupportedException: Close is not supported
   at FlaUI.Core.AutomationElements.Window.Close()
   at Program.Main()
that error when teamviewer on second screen you must run this program with single screen only
```powershell
cd [Path of TeamViewWake.exe]
```
```powershell
powershell -ExecutionPolicy Bypass -File .\run.ps1
```
```powershell
powershell Get-Content C:\Users\NB-67-06-01\TeamViewWake\TeamViewWake.log -Tail 50
```
