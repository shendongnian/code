    private System.Timers.Timer _timer;
    
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
