    using System;
    
    namespace Intervals
    {
        public class Interval
        {
            private System.Timers.Timer timer;
            private Action main;
    
            public Interval()
            {
                timer = new System.Timers.Timer();
            }
    
            public void setInterval(Action pAction, int interval)
            {
                if (interval <= 0) { interval = 100; }
                timer.Interval = interval;
    
                main = new Action(delegate{
                    timer.Stop();
                    pAction?.Invoke();
                    timer.Start();
                });
    
                timer.Elapsed += (sender, e) => TimerEventProcessor(sender, e);
                timer.Start();
            }
    
            public void changeInterval(int interval)
            {
                timer.Stop();
                timer.Interval = interval;
                timer.Start();
            }
    
            public void clearInterval()
            {
                main?.EndInvoke(null);
    
                main = delegate
                {
                    timer.Stop();
                    timer.Dispose();
                };
            }
    
            public void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
            {
                main?.Invoke();
            }
        }
    }
