    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Timers;
    public class Program
    {
        static void Main(string[] args)
        {
            int MsToWait = 3000;
            int MsElapsed = 0;
            WaitLaunch:
            System.Threading.Thread.Sleep(100);
            MsElapsed += 100;
            if (MsElapsed >= MsToWait)
            {
                Process.Start(@"C:\WINDOWS\system32\notepad.exe");
                return;
            }
            else
                goto WaitLaunch;
        }
    }
