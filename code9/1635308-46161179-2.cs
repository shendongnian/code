    protected override void OnStart(string[] args)
    {
        // Log a service start message to the Application log.
        EventLog.WriteEntry("My Service in OnStart.");
        timer = new System.Timers.Timer(50000);
        timer.AutoReset = true;
        timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Tick);
        timer.Start();
    }
    protected override void OnStop()
    {
        // Log a service stop message to the Application log.
        EventLog.WriteEntry("My Service in OnStop.");
    }
