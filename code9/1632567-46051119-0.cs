    using System;
    using System.Threading;
    
    namespace FiringTheTimerTestHarness
    {
        class Program
        {
            public static Thread _worker;
            public static Timer _timer;
            static void Main(string[] args)
            {
                _worker = new Thread(new ThreadStart(ThreadWorker));
                _worker.Start();
                var startTime = DateTime.Now;
                // Simulate the main UI thread being active doing stuff (i.e. if there's a Windows Forms app so we don't need anything to 
                // keep the app "alive"
                while (1==1)
                {
                    Thread.Sleep(100);
                    if (startTime.AddSeconds(30) < DateTime.Now)
                    {
                        // Lets pretend that we need to fire the timer *now* so that we can get the result *now*
                        _timer.Change(0, 5000);
                    }
                }
            }
    
            public static void ThreadWorker()
            {
                _timer = new Timer(new TimerCallback(DoStuffEveryFiveSeconds), null, 5000, 5000);
                while (1 == 1)
                {
                    Thread.Sleep(100);
                }
            }
    
            public static void DoStuffEveryFiveSeconds(object state)
            {
                Console.WriteLine("{0}: Doing stuff", DateTime.Now);
            }
        }
    }
