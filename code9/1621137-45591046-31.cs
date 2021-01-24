    namespace Intervals
    {
        class Interval
        {
            // This is the method to run when the timer is raised.
            private static void TimerEventProcessor(
                System.Object myObject,
                System.EventArgs myEventArgs,
                System.Action myAction,
                System.Windows.Forms.Timer myTimer
            )
            {
                myTimer.Stop();
                myAction?.Invoke();
                myTimer.Start();
            }
        
            public static System.Windows.Forms.Timer setInterval(System.Action action, int timeInMs)
            {
                if (timeInMs <= 0) {
                    timeInMs = 100;
                }
    
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = timeInMs;
                timer.Start();
                timer.Tick += (sender, e) => TimerEventProcessor(sender, e, action, timer);
    
                return timer;
            }
    
            public static void clearInterval(System.Windows.Forms.Timer timer)
            {
                timer.Stop();
                timer.Dispose(); //release any ressources, e.g. event handlers
            }
        }
    }
