    System.Timers.Timer timer = null;
    public void FadeOut(object sender, EventArgs e)
    {
        // ----
        // do the incremental fade step here
        // ----
        // end conditions
        if ([current_color] <= [end_color])
        {
            timer.Stop();
            // trigger any additional things you want, like close window
        }
    }
    public void AsyncFadeOut()
    {
        System.Timers.Timer timer = new System.Timers.Timer(10); // triggers every 10ms, change this if you want a faster/slower fade
        timer.Elapsed += new System.Timers.ElapsedEventHandler(FadeOut);
        timer.AutoReset = true;
        timer.Start();
    }
    
