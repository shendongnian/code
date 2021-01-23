    // set interval of 3 seconds / 3000 msec
    System.Timers.Timer timer = new System.Timers.Timer(3000);
    // the timer will restart automatically
    timer.AutoReset = true;
    // register the event
    timer.Elapsed += Timer_Elapsed;
    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        // execute method here
        // check whether timer can be stopped
        System.Timers.Timer t = sender as System.Timers.Timer;
        if (someCondition)
        {
            t.AutoReset = false;
        }
    }
