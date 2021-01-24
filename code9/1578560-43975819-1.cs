    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections.Generic;
    using System.Timers;
    
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                TimeOut timeOut = new TimeOut();
                timeOut.TimePassed += timeOut_TimePassed;
                timeOut.Initiate();
                timeOut.Start();
    
                Console.Read();
            }
            
            // Changed this
            private static void timeOut_TimePassed(object sener, System.EventArgs e)
            {
                var x = 1;
            }
        }
    
        public class TimeOut
        {
            private readonly int TIME_OUT = 60;
            private System.Timers.Timer _timer;
            private Stopwatch _stopwatch;
            // Changed this
            public delegate void TimeOutHandler(object sener, EventArgs e);
            public event TimeOutHandler TimePassed;
    
            public void Initiate()
            {
                _timer = new System.Timers.Timer();
                _timer.Interval = 1000;
                _timer.Elapsed += _timer_Elapsed;
                _stopwatch = new Stopwatch();
            }
    
            public void Start()
            {
                _stopwatch.Start();
                _timer.Start();
            }
    
            public void _timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                if (_stopwatch.ElapsedMilliseconds / 1000 >= TIME_OUT)
                {
                    if (TimePassed != null)
                    {
                        TimePassed(sender, null);
                        Stop();
                    }
                }
            }
    
            public void Stop()
            {
                _timer.Stop();
                _stopwatch.Stop();
            }
        }
    }
