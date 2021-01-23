    using System.Configuration;
    using System.Diagnostics;
    namespace RegressionTesting.Common.ThirdParty
    {
        public class ClickAtBrowserPosition
        {
            public static void CallClickAtBrowserPosition(string currentBrowserWindowTitle, int xPosition, int yPosition)
            {
                var pathClickAtBrowserPosition = ConfigurationManager.AppSettings["pathClickAtBrowserPosition"];
                var clickAtBrowserPositionExe = ConfigurationManager.AppSettings["clickAtBrowserPositionExe"];
                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden, // don't show the cmd.exe which calls the program
                    FileName = "cmd.exe",
                    Arguments = @" /C cd " +
                                $@"""{pathClickAtBrowserPosition}"" && {clickAtBrowserPositionExe} ""{currentBrowserWindowTitle}"" {xPosition} {yPosition}"
                };
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit(); // wait to finish the execution
            }
        }
    }
