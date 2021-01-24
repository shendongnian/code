    void threadmethod()
    {
        System.Timers.Timer t = new System.Timers.Timer();
        t.Enabled = true;
        t.Interval = 100;
        t.Elapsed += T_Tick;
        t.AutoReset = true;
    }
