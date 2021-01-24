	public static TimeSpan RunNTimes(this Action a, int nTimes = 1)
	{
		if (nTimes == 0)
			throw new ArgumentException("0 times not allowed", nameof(nTimes));
		var stopwatch = new Stopwatch();
		
		stopwatch.Start();
		for (int i = 0; i < nTimes; ++i)
			a();
		stopwatch.Stop();
		
		return stopwatch.Elapsed;;
	}
