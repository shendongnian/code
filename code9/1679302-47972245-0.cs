    // set the interval you prefer
    System.Timers.Timer timer = new System.Timers.Timer(500); 
    timer.Elapsed += OnElapsed;
    timer.AutoReset = true;
    timer.Enabled = true;
