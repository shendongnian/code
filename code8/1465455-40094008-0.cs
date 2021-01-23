    System.Timers.Timer _timer;
    protected override void OnStart(string[] args)
    {
        [...]
        _timer = new System.Timers.Timer();
        _timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
        _timer.Start();
        [...]
