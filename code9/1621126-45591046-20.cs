    namespace Intervals
    {
        /*
         *  Es existieren mehrere Überladungen.
         */
        class Interval
        {
            private int _ival;
    
            public int Ival
            {
                get { return _ival; }
                set
                {
                    if (_ival > 0)
                    {
                        _ival = value;
                    }
                    else
                    {
                        _ival = 1;
                    }
                }
            }
    
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
                //restart the timer
                myTimer.Enabled = true;
            }
    
            private static void TimerEventClear(
                System.Object myObject,
                System.EventArgs myEventArgs,
                System.Windows.Forms.Timer myTimer
            )
            {
                myTimer.Stop();
            }
    
            public static System.Windows.Forms.Timer setInterval(System.Action action, int timeInMs)
            {
    
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = timeInMs;
                timer.Start();
                timer.Tick += (sender, e) => TimerEventProcessor(sender, e, action, timer);
    
                return timer;
            }
    
            /*
             * Stops the interval immediately.
             * 
             */
            public static void clearInterval(System.Windows.Forms.Timer timer)
            {
                timer.Stop();
            }
    
            /*
             * Stops the interval after its next run.
             * 
             */
            public void clearIntervalAfterNextRun(System.Windows.Forms.Timer timer)
            {
                timer.Tick += (sender, e) => TimerEventClear(sender, e, timer);
            }
        }
    }
