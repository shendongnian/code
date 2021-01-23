    private static AutoResetEvent TimerWaitHandle = new AutoResetEvent(false);
    static void Main()
    {
        // Initialize timer
        var timerPeriod = TimeSpan.FromMilliseconds(500);
        Timer timer = new Timer(TimerCallback, null, timerPeriod, timerPeriod);
        while(true)
        {
            // Here perform your game logic
            // Suspend main thread until next timer's tick
            TimerWaitHandle.WaitOne();
            // It is sometimes useful to wake up thread by more than event,
            // for example when new user connects etc. WaitHandle.WaitAny()
            // allows you to wake up thread by any event, whichever occurs first.
            //WaitHandle.WaitAny(new[] { TimerWaitHandle, tcpListener.BeginAcceptSocket(...).AsyncWaitHandle });
        }
    }
    static void TimerCallback(Object state)
    {
        // If possible, you can perform desired game logic here, but if you
        // need to handle it on main thread, wake it using TimerWaitHandle.Set()
        TimerWaitHandle.Set();
    }
