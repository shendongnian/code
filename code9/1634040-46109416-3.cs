    DateTime now = DateTime.Now;
	TimeSpan t = new TimeSpan(0);
	if (now.Hour >= 20)
	{
		DateTime nextDay = now.AddDays(1);
		t = new DateTime(nextDay.Year, nextDay.Month, nextDay.Day, 8, 0, 0).Subtract(now);
	}
	else if (now.Hour < 8)
	{
		t = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0).Subtract(now);
	}
	Console.WriteLine(t);
