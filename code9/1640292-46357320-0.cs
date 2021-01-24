    private long _lockTicks = 0;
    .....
    var sw = StopWatch.StartNew();
    lock(_locker)
    {
       sw.Stop();
       _lockTicks += sw.ElapsedTicks;
       //dostuff
    }
    ......
    double seconds = (double)_lockTicks / StopWatch.Frequency;
