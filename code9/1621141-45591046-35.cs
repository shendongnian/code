    using System;
    
    namespace Intervals
    {
        class Interval
        {
            // This is the method to run when the timer is raised.
            private static void TimerEventProcessor(
                Object myObject,
                EventArgs myEventArgs,
                Action myAction,
                System.Timers.Timer myTimer
            )
            {
                myTimer.Stop();
                myAction?.Invoke();
                myTimer.Start();
            }
    
            public static System.Timers.Timer setInterval(Action action, int timeInMs)
            {
                if (timeInMs <= 0) {
                    timeInMs = 100;
                }
    
                System.Timers.Timer timer = new System.Timers.Timer(timeInMs);
                timer.Elapsed += (sender, e) => TimerEventProcessor(sender, e, action, timer);
                timer.Start();
    
                return timer;
            }
    
            public static void changeInterval(System.Timers.Timer timer, int interval)
            {
                timer.Stop();
                timer.Interval = interval;
                timer.Start();
            }
    
            public static void clearInterval(System.Timers.Timer timer)
            {
                timer.Stop();
                timer.Dispose();
            }
        }
    }
