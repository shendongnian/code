    //...other code removed for brevity
    private const string logName = "Application";
    protected override void OnStart(string[] args) {
        if (!EventLog.SourceExists(this.ServiceName)) {
            EventLog.CreateEventSource(this.ServiceName, logName);
        }
        //set the The source name by which the application is registered on the local computer.
        BackUpLog.Source = this.ServiceName;
        //The name of the log the source's entries are written to. 
        //Possible values include Application, System, or a custom event log. 
        BackUpLog.Log = logName;
        BackUpLog.WriteEntry("Database Backup has begun.");
        _timer = new System.Timers.Timer { Interval = 3600000 };
        _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
        _timer.Start();
        Backup();
    }
    //...other code removed for brevity
