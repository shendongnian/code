    using System;
    using System.Threading;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main()
            {
                int interval = 1000;
                string s = "sample object";
                Timer t = null;
                using (t = new Timer(
                    state =>
                    {
                        var nextTime = DateTime.Now.AddMilliseconds(interval);
                        // do work on object in method scope, so thought to declare timer callback here
                        Console.WriteLine("Doing work with " + s);
                        // but timer callback should call Change on itself
                        t.Change(Math.Max(nextTime.Subtract(DateTime.Now).Milliseconds, 100), Timeout.Infinite);
                    }, null, interval, Timeout.Infinite))
                {
                    var finishTime = DateTime.Now.AddSeconds(10);
                    while (finishTime > DateTime.Now)
                    {
                        Thread.Sleep(333);
                        Console.WriteLine($"{(finishTime - DateTime.Now).TotalSeconds} remaining.");
                    }
                }
            }
        }
    }
