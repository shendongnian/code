    var V_max = 254;
    var V_progress = 0.0;
    var timespan = new TimeSpan(0, 0, 0, 5, 0);
    var stopwatch = new Stopwatch();
    var timer = new System.Timers.Timer(10);
    timer.Elapsed += (sender, e) =>
    {
        var elapsedMs = stopwatch.Elapsed.TotalMilliseconds;
        var percentage = stopwatch.Elapsed.TotalMilliseconds / timespan.TotalMilliseconds;
        if (percentage >= 1.0)
        {
            timer.Stop();
            stopwatch.Stop();
            percentage = 1.0;
        }
        // probably dispatch this assignment to the UI thread for the actual code
        V_progress = percentage * V_max;
        // test output
        Console.WriteLine(V_progress);
    };
    stopwatch.Start();
    timer.Start();
