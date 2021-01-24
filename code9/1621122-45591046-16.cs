    using System;
    using System.Windows.Forms;
    using System.Threading.Tasks;
    
    namespace Intervals
    {
        /*
         *  Es existieren mehrere Überladungen.
         */
        class Interval
        {
            private System.Windows.Forms.Timer _myTimer;
            private Func<Task> _myAsyncMethod;
            private Func<int> _myIntMethod;
    
            private int _ival;
    
            public System.Windows.Forms.Timer Timer
            {
                get { return _myTimer; }
                set { _myTimer = value; }
            }
    
            public Func<Task> MyAsyncMethod
            {
                get { return _myAsyncMethod; }
                set { _myAsyncMethod = value; }
            }
    
            public Func<int> MyIntMethod
            {
                get { return _myIntMethod; }
                set { _myIntMethod = value; }
            }
    
            public int Ival
            {
                get { return _ival; }
                set
                {
                    if (_ival > 0) {
                        _ival = value;
                    } else {
                        _ival = 1;
                    }
                }
            }
    
            // This is the method to run when the timer is raised.
            private static void TimerEventProcessor(
                Object myObject,
                EventArgs myEventArgs,
                Func<int> myMethod,
                Timer myTimer
            )
            {
                myTimer.Stop();
                myMethod?.Invoke();
                //restart the timer
                myTimer.Enabled = true;
            }
    
    
            private static void TimerEventProcessor(
                Object myObject,
                EventArgs myEventArgs,
                Func<Task> myMethod,
                Timer myTimer
            )
            {
                myTimer.Stop();
                myMethod?.Invoke();
                //restart the timer
                myTimer.Enabled = true;
            }
    
    
            public Timer setInterval(Func<Task> pMethod, int timeInMs)
            {
                MyAsyncMethod = pMethod;
                Timer = new Timer();
                Timer.Interval = timeInMs;
                Timer.Start();
                Timer.Tick += (sender, e) => TimerEventProcessor(sender, e, pMethod, Timer);
    
                return Timer;
            }
    
            public Timer setInterval(Func<int> pMethod, int timeInMs)
            {
                MyIntMethod = pMethod;
                Timer = new Timer();
                Timer.Interval = timeInMs;
                Timer.Start();
                Timer.Tick += (sender, e) => TimerEventProcessor(sender, e, pMethod, Timer);
    
                return Timer;
            }
    
            /*
             * Stops the interval immediately.
             * 
             */
            public void clearInterval()
            {
                Timer.Stop();
            }
    
            /*
             * Stops the interval after its next run.
             * 
             */
            public void clearIntervalAfterNextRun()
            {
                Timer.Tick += (sender, e) => TimerEventClear(sender, e, Timer);
            }
    
            private static void TimerEventClear(
                Object myObject,
                EventArgs myEventArgs,
                Timer myTimer
            )
            {
                myTimer.Stop();
            }
        }
    }
