    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Timers;
    
    namespace TimersTest
    {
        class Program
        {
            private static int ConcurrentTimerCount = 100;
            private static int Counter = 0;
            private static object SyncObj = new object();
            private static ManualResetEvent Done = new ManualResetEvent(false);
    
            static void Main(string[] args)
            {
                var timers = new List<System.Timers.Timer>();
                for (var i = 0; i < ConcurrentTimerCount; i++)
                {
                    var timer = new System.Timers.Timer(3000);
                    timer.Elapsed += TimerElapsed;
                    timers.Add(timer);
                }
    
                var stopwatch = new Stopwatch();
                stopwatch.Start();
    
                Console.WriteLine("Starting timers in 3 seconds...");
    
                timers.ForEach(t => t.Start());
                Done.WaitOne();
    
                stopwatch.Stop();
                Console.WriteLine("Timers are all done in {0} ms.", stopwatch.ElapsedMilliseconds - TimeSpan.FromSeconds(3).TotalMilliseconds);
            }
    
            private static void TimerElapsed(object sender, ElapsedEventArgs e)
            {
                // Simulate 100 ms processing time.
                Thread.Sleep(100);
    
                lock (SyncObj)
                {
                    Counter += 1;
    
                    if (Counter == ConcurrentTimerCount)
                    {
                        Done.Set();
                    }
                }
            }
        }
    }
