	var today = DateTime.UtcNow;
	var bookedTimes = new[]
	{
		new DateRange(new DateTime(today.Year, today.Month, today.Day, 07, 00, 00),
			new DateTime(today.Year, today.Month, today.Day, 09, 00, 00)),
		new DateRange(new DateTime(today.Year, today.Month, today.Day, 09, 00, 00),
			new DateTime(today.Year, today.Month, today.Day, 11, 00, 00)),
		new DateRange(new DateTime(today.Year, today.Month, today.Day, 13, 00, 00),
			new DateTime(today.Year, today.Month, today.Day, 14, 00, 00)),
		new DateRange(new DateTime(today.Year, today.Month, today.Day, 18, 00, 00),
			new DateTime(today.Year, today.Month, today.Day, 20, 00, 00)),
	};
	var freeTimes = new List<DateRange>();
	for (var i = 0; i < bookedTimes.Length -1; i++)
	{
		var current = bookedTimes[i];
		var next = bookedTimes[i + 1];
		if (current.To != next.From)
		{
			var range = new DateRange(current.To, next.From);
			freeTimes.Add(range);
		}
	}
	foreach (var time in freeTimes)
	{
		Console.WriteLine($"From {time.From.ToShortTimeString()}, to: {time.To.ToShortTimeString()}");
	}
	// Outputs:
	// From 11:00, to: 13:00
	// From 14:00, to: 18:00
