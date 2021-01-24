    struct TimerStatus
    {
        DateTime StartTime;
        bool IsRunning;
    }
    TimerStatus[] _timers = new TimerStatus[10];
    void Start1_Click()
    {
        _timers[1].StartTime = System.DateTime.Now;
        _timers[1].IsRunning = true;
    }
    void Stop1_Click()
    {
        _timers[1].IsRunning = false;
    }
    void Start2_Click()
    {
        _timers[2].StartTime = System.DateTime.Now;
        _timers[2].IsRunning = true;
    }
    void Stop2_Click()
    {
        _timers[2].IsRunning = false;
    }
    void OneAndOnlyTimer_Tick()
    {
        for (int i=0; i<=_timers.GetUpperBound(0); i++)
        {
            if (_timers[i].IsActive) 
            {
                TimeSpan ts = System.DateTime.Now - _timers[i].StartTime;
                DisplayTimer(i, ts.Hours, ts.Minutes, ts.Seconds);  //You will need to write the method that does the display
            }
        }
    }
