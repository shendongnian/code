	public static async void RunSheduledTasks(TimeSpan endTime, params Action[] tasks)
    {
		DateTime endDate = DateTime.Today.Add(endTime);
		if (endDate < DateTime.Now) 
			endDate = endDate.AddDays(1.0);
		while (true)
		{
			TimeSpan duration = endDate.Subtract(DateTime.Now);
			if(duration.TotalMilliseconds <= 0.0)
			{ 
				Parallel.Invoke(tasks);
				endDate = endDate.AddDays(1.0);
				continue;
			}
			int delay = (int)(duration.TotalMilliseconds / 2);
			await Task.Delay(delay > 0 ? delay : 0);
		}
	}
