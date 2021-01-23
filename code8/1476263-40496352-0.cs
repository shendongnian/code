    using System;
    using System.Diagnostics;
    
    namespace runGnomeTerminal
    {
        class MainClass
        {
            public static void ExecuteCommand(string command)
            {
                Process proc = new System.Diagnostics.Process ();
                proc.StartInfo.FileName = "/bin/bash";
                proc.StartInfo.Arguments = "-c \" " + command + " \"";
                proc.StartInfo.UseShellExecute = false; 
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start ();
    
                while (!proc.StandardOutput.EndOfStream) {
                    Console.WriteLine (proc.StandardOutput.ReadLine ());
                }
            }
    
            public static void Main (string[] args)
            {
                ExecuteCommand("gnome-terminal -x bash -ic 'cd $HOME; ls; bash'");
            }
    
    
        }
    }
