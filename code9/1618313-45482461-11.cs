    // Call that method as close as you can from the startup of your application
    Task.Run(() => DailyResetSequence());
	private async void DailyResetSequence()
	{
		while (true)
		{
			using (var dbContext = new DbContext())
			{
				var tomorrow = DateTime.Now.AddDays(1);
				var sleepingTime = tomorrow - DateTime.Now;
				// waiting until tomorrow morning
				await Task.Delay(sleepingTime);
                // See below
				dbContext.ResetSequence();
			}
		}
	}
