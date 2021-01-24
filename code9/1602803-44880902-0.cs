    // trigger initially in 1ms
    System.Timers.Timer timer = new System.Timers.Timer(1);
    timer.Elapsed += timer_Elapsed;
    timer.AutoReset = false;
    timer.Start();
