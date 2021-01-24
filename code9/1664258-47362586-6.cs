	long lastRun = 0;
	long cooldown = TimeSpan.FromSeconds(1).Ticks; // Or whatever, I do not know.
	// ...
	bool canRun = false;
	long lastRunCopy = 0;
	long now = DateTime.Now.Ticks;
	lastRunCopy = Interlocked.CompareExchange(ref lastRun, now, 0);
	if (lastRunCopy == 0)
	{
		// We set lastRun
		canRun = true;
	}
	else
	{
		if ((now - lastRunCopy) < cooldown)
		{
			if (Interlocked.CompareExchange(ref lastRun, now, lastRunCopy) == lastRunCopy)
			{
				// we updated it
				canRun = true;
			}
			else
			{
				// Another thread got in
			}
		}
	}
    if (canRun)
    {
        // code here will only run once per cooldown
    }
