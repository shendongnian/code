    DateTime LastTime = DateTime.Now;
    ...
    DateTime NextTime = LastTime + ASecond;
    // Just in case we have gone past the next time (perhaps you put the system to sleep?)
    if (DateTime.Now > NextTime)
        NextTime = DateTime.Now + ASecond;
    TimeSpan Duration = NextTime - DateTime.Now;
    LastTime = NextTime;
    timer1.Interval = (int)Duration.TotalMilliseconds;
