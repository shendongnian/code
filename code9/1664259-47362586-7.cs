    long lastRun = 0;
    long cooldown = TimeSpan.FromSeconds(1).Ticks; // Or whatever, I do not know.
    // ...
    long lastRunCopy;
    var now = DateTime.Now.Ticks;
    if
    (
        (lastRunCopy = Interlocked.CompareExchange(ref lastRun, now, 0)) == 0
        || now - lastRunCopy < cooldown
        && Interlocked.CompareExchange(ref lastRun, now, lastRunCopy) == lastRunCopy
    )
    {
        // code here will only run once per cooldown
    }
