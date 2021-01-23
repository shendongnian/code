    public MainViewModel()
    {
        this.Duration = 1000;
        this.Text = "00";
        this.timer = new DispatcherTimer(); //<--Add this line
        this.StartTimerCommand = new Delegatecommon(this.StartTimer);
        this.StopTimerCommand = new Delegatecommon(this.StopTimer);
    }
