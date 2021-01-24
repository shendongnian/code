    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Collections;
    using System.Collections.Generic;
    public class Program
    {
        static Dictionary<string,DateTime> ExecutablesToLaunch = new Dictionary<string,DateTime>();
        static List<string> ExecutablesLaunched = new List<string>();
        static void Main(string[] args)
        {
            ExecutablesToLaunch.Add(@"C:\WINDOWS\system32\notepad.exe", DateTime.Now.AddSeconds(3));
            ExecutablesToLaunch.Add(@"C:\WINDOWS\system32\control.exe", DateTime.Now.AddSeconds(5));
            ExecutablesToLaunch.Add(@"C:\WINDOWS\system32\calc.exe", DateTime.Now.AddSeconds(10));
    
            WaitAllToLaunch:
            if (ExecutablesToLaunch.Count == ExecutablesLaunched.Count)
                return;
            Thread.Sleep(100);
            foreach (var Executable in ExecutablesToLaunch)
            {
                if (ExecutablesLaunched.Contains(Executable.Key))
                    continue;
                if (DateTime.Now >= Executable.Value)
                {
                    Process.Start(Executable.Key);
                    ExecutablesLaunched.Add(Executable.Key);
                }
                else
                    goto WaitAllToLaunch;
            }
        }
    
    }
