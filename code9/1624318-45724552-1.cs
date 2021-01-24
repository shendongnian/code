	Device.StartTimer(new TimeSpan(0, 0, 1), () =>
	{
		if (stopWatch.IsRunning && stopWatch.Elapsed.Minutes == 2)
		{
			myMethod().ContinueWith((Task t) =>
			{
				stopWatch.Restart();
				return true;
			});
		}
		return true;
	});
