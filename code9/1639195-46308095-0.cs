	var start = new DateTime(DateTime.UtcNow.Year, 1, 1);
	var end = start.AddYears(1);
	while (start < end)
	{
		if (start.DayOfWeek == DayOfWeek.Monday)
		{
			Console.WriteLine(start);
			start = start.AddDays(7);
		}
		else
		start = start.AddDays(1);
	}
