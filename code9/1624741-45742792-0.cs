    using System;
    using System.Diagnostics;
    namespace ConsoleApplication13
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Set oShell = CreateObject("Wscript.Shell")
                var shellType = Type.GetTypeFromProgID("Wscript.Shell");
                dynamic shell = Activator.CreateInstance(shellType);
                //Dim strArgs
                //strArgs = "cmd /c LayoutsBackup.bat"
                //oShell.Run strArgs, 0, false
                var startArgs = new ProcessStartInfo
                {
                    Arguments = "/c LayoutsBackup.bat",
                    FileName = "cmd",
                    CreateNoWindow = false,
                    UseShellExecute = false
                };
                var shellProcess = Process.Start(startArgs);
                shellProcess.WaitForExit(); /* optional */
            }
        }
    }
