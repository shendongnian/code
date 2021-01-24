    using System;
    using System.Diagnostics;
    using System.Threading;
    public class Program
    {
        static void Main(string[] args)
        {
            DateTime LaunchAt = DateTime.Now.AddSeconds(3);
            WaitLaunch:
            Thread.Sleep(100);
            if (DateTime.Now >= LaunchAt)
                Process.Start(@"C:\WINDOWS\system32\notepad.exe");
            else
                goto WaitLaunch;
        }
    }
