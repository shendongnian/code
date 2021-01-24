    private System.Timers.Timer _timer;
    
    protected override void OnStart(string[] args)
    {
        _timer = new System.Timers.Timer { Interval = 1000 };
        _timer.Elapsed += TimerElapsed;
        _timer.Enabled = true;
    }
    /// <summary>
    /// Event raised every second
    /// IsBusy flag ensures no overlapping processing
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!IsRunning) return;
            if (IsBusy) return; //Line was commented out
            IsBusy = true;
            ProcessRequestLogRecords();
            IsBusy = false;
        }
