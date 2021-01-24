    //Equivalent to:
    //Stopwatch stopWatch = new Stopwatch();
    //stopWatch.Start();
    Stopwatch stopWatch = Stopwatch.StartNew();
    //Operation you want to measure
    stopWatch.Stop();
    //Timespan is a struct to hold time related info..
    //e.g: Days, Hours, Seconds, Milliseconds, Ticks and TotalDays... etc
    Timespan ts = stopWatch.Elapsed;
    //Or you can simply get the time elapsed in milliseconds like this
    long elapsed = stopWatch.ElapsedMilliseconds;
    
    //QueryPerformanceFrequency 
    long frequency = Stopwatch.Frequency;
    
    //QueryPerformanceCounter
    long ticks = Stopwatch.GetTimestamp();
