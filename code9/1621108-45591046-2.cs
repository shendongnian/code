    using System;
    using System.Windows.Forms;
    
    namespace Intervals
    {
        class IntervalMain
        {
            private System.Windows.Forms.Timer _myTimer;
            private Func<int> _myMethod;
    
            private int _ival;
    
            public System.Windows.Forms.Timer myTimer
            {
                get { return _myTimer; }
                set { _myTimer = value; }
            }
    
            public Func<int> myMethod
            {
                get { return _myMethod; }
                set { _myMethod = value; }
            }
    
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
    
            //Construktor
            public IntervalMain(Func<int> pMethod, int timeInMs)
            {
                myMethod = pMethod;
                myTimer = new Timer();
                myTimer.Interval = timeInMs;
                myTimer.Start();
                myTimer.Tick += (sender, e) => TimerEventProcessor(sender, e, myMethod, myTimer);
            }
    
            // This is the method to run when the timer is raised.
            private static void TimerEventProcessor(
                Object myObject,
                EventArgs myEventArgs,
                Func<int> myMethod,
                Timer t
            )
            {
                t.Stop();
    
                myMethod?.Invoke();
    
                //restart the timer
                t.Enabled = true;
            }
        }
    
        class Interval
        {
            private IntervalMain _IvalObj;
    
            public IntervalMain IvalObj
            {
                get { return _IvalObj; }
                set { _IvalObj = value; }
            }
    
            public Timer setInterval(Func<int> myMethod, int timeInMs)
            {
                IvalObj = new IntervalMain(myMethod, timeInMs);
    
                return IvalObj.myTimer;
            }
    
            /*
             * Stops the interval immediately.
             * 
             */
            public void clearInterval()
            {
                _IvalObj.myTimer.Stop();
            }
    
            /*
             * Stops the interval after its next run.
             * 
             */
            public void clearIntervalAfterNextRun()
            {
                _IvalObj.myTimer.Tick += (sender, e) => TimerEventClear(sender, e, IvalObj);
            }
    
            private static void TimerEventClear(Object myObject, EventArgs myEventArgs, IntervalMain IvalObj)
            {
                IvalObj.myTimer.Stop();
            }
        }
    }
