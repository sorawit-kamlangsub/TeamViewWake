using FlaUI.UIA3;
using FlaUI.Core.Conditions;
using System.Diagnostics;
using FlaUI.Core.AutomationElements;
using TextCopy;
class Program
{

    [STAThread]
    static void Main()
    {

        string teamViewerPath = @"C:\Program Files\TeamViewer\TeamViewer.exe";


        var launch = FlaUI.Core.Application.Launch(teamViewerPath);
        var process = Process.GetProcessesByName("TeamViewer").FirstOrDefault();
        if (process == null)
        {
            Console.WriteLine("TeamViewer process not found.");
            return;
        }
        var app = FlaUI.Core.Application.Attach(process);

        var automation = new UIA3Automation();
        var window = app.GetMainWindow(automation);
        ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());


        var coppyButton = window?.FindAllDescendants(cf => cf.ByName("Copy your ID to the clipboard."));

        var listTexts = new List<string>();
        foreach (var item in coppyButton)
        {
            item?.AsButton().Click();
            var clipboardText = ClipboardService.GetText() ?? "-";
            var listText = clipboardText;
            listTexts.Add(listText);
        }
        var clipboardTexts = string.Join("\n", listTexts);

        string exeDir = AppDomain.CurrentDomain.BaseDirectory;
        string exeName = Path.GetFileNameWithoutExtension(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        string logPath = Path.Combine(exeDir, exeName + ".log");
        File.AppendAllText(logPath, DateTime.Now + Environment.NewLine + clipboardTexts + Environment.NewLine);

        window?.Close();

    }


}
