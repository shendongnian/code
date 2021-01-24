	public void SetUpTimer(TimeSpan alertTime)
	{
		DateTime targetDateTime = DateTime.Today.Add(alertTime);
		if (targetDateTime < DateTime.Now)
		{
			targetDateTime = targetDateTime.AddDays(1);
		}
		TimeSpan timeToGo = targetDateTime - DateTime.Now;
		timer = new System.Threading.Timer(x =>
		{
			EventLog.WriteEntry("MhyApp", "Timer Set  " + timeToGo);
			this.MethodRunsAt();
		}, null, timeToGo, System.Threading.Timeout.InfiniteTimeSpan);
	}
