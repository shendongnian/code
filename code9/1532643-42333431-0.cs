    using System;
    using System.Diagnostics;
    using System.Timers;
    
    public class Program
    {
        private static Timer _Timer;
        private static bool Launched = false;
        static void Main(string[] args)
        {
            SetupTimer();
            WaitUntilItIsLaunched:
            if (!Launched)
            {
                System.Threading.Thread.Sleep(100);
                goto WaitUntilItIsLaunched;
            }
        }
    
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Process.Start(@"C:\WINDOWS\system32\notepad.exe");
            Launched = true;
        }
    
        private static void SetupTimer()
        {
            _Timer = new Timer();
            _Timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            _Timer.Interval = 3000;
            _Timer.Enabled = true;
        }
    }
