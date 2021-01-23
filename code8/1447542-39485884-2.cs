    public MainViewModel()
    {
        this.Duration = 1000;
        this.Text = "00";
        timer = new DispatcherTimer();
        timer.Interval = this.Duration;
        timer.Tick += new EventHandler(TimerTick);
        this.StartTimerCommand = new Delegatecommon(this.StartTimer);
        this.StopTimerCommand = new Delegatecommon(this.StopTimer);
    }
    public void StartTimer()
    {
        timer.Start();
    }
    public void StopTimer()
    {
        timer.Stop();
    }
