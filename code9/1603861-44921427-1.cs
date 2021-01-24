    public static TimeSpan GetTimestampFor(Action action)
		{
			TimeSpan timestamp = new TimeSpan(0);
			Stopwatch stopWatch = new Stopwatch();
			if (action != null)
			{
				stopWatch.Start();
				action.Invoke();
				stopWatch.Stop();
				timestamp = stopWatch.Elapsed;
			}
			return timestamp;
		}
