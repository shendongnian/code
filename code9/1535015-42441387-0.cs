    private double interval = 1000; // one second interval so progress bar updates every second.
    private TimeSpan elapsed; // time span that reaches 5 minutes. this will reset to 0 after 5 minutes.
    private TimeSpan totalElapsed; // total time passed. used to set value of progress bar
    private bool progressPaused; // flag, true if progressbar is at 2 min pause, otherwise false
    private void timer1_Tick(object sender, EventArgs e)
    {
        const int fiveMinutes = 5*1000*60;
        const int twoMinutes = 2*1000*60;
        const int totalMinutes = 20*1000*60;
        var timer = (Timer) sender; // assuming Timer is System.Timers.Timer
        if(timer.Enabled == false) return;
        if (progressPaused) 
        {
            // progressbar was paused. prepare to start again
            timer.Enabled = false;
            timer.AutoReset = true;
            timer.Interval = interval; // previous interval
            progressPaused = false;
            timer.Enabled = true;
            return;
        }
        // add interval of timer to TimeSpans
        totalElapsed = totalElapsed.Add(TimeSpan.FromMilliseconds(timer.Interval));
        elapsed = elapsed.Add(TimeSpan.FromMilliseconds(timer.Interval));
        if (elapsed.Milliseconds > fiveMinutes) // if we reached 5 minutes
        {
            elapsed = default(TimeSpan); // reset timespan from 5 min to 0
            timer.Enabled = false;
            timer.AutoReset = false; // auto reset should be off because we only pause once per 2 minutes. (although this may have no effect)
            interval = timer.Interval;
            timer.Interval = twoMinutes; // two minute pause
            progressPaused = true; // set falg
            timer.Enabled = true;
        }
        circularProgressBar1.Value = (int)(totalElapsed.Milliseconds/(double)totalMinutes*100); // calculate new progressbar value. (elapsed/total*100)
        circularProgressBar1.Text = circularProgressBar1.Value.ToString();
        circularProgressBar1.SuperscriptText = "%";
    }
