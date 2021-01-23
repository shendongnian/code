	var events = new List<Tuple<DateTime, DateTime>>
	{
        // start and end after time of day but on different days
		Tuple.Create(
            new DateTime(2017, 02, 17, 22, 0, 0), 
            new DateTime(2017, 02, 18, 15, 0, 0)),
        // start and end before time of day but on different days 
		Tuple.Create(
            new DateTime(2017, 02, 17, 9, 0, 0), 
            new DateTime(2017, 02, 18, 7, 0, 0)),
        // start before and end after same day 
		Tuple.Create(
            new DateTime(2017, 02, 17, 9, 0, 0), 
            new DateTime(2017, 02, 17, 11, 0, 0)),
        // covers more than 1 day
		Tuple.Create(
            new DateTime(2017, 02, 17, 22, 0, 0), 
            new DateTime(2017, 02, 18, 22, 0, 1)),
        // start after and end before on different days 
		Tuple.Create(
            new DateTime(2017, 02, 17, 22, 0, 0), 
            new DateTime(2017, 02, 18, 10, 0, 0)), 
        // start and end before on same day
		Tuple.Create(
            new DateTime(2017, 02, 17, 7, 0, 0), 
            new DateTime(2017, 02, 17, 8, 0, 0)), 
        // start and end after on same day
		Tuple.Create(
            new DateTime(2017, 02, 17, 11, 0, 0), 
            new DateTime(2017, 02, 17, 12, 0, 0)), 
	};
	var timeOfDay = new TimeSpan(0, 10, 0 ,0);
	foreach (var x in events)
	{
		if (x.Item2 - x.Item1 > TimeSpan.FromDays(1)
			|| (x.Item1.TimeOfDay < timeOfDay && x.Item2.TimeOfDay > timeOfDay)
			|| (x.Item1.Date < x.Item2.Date 
                && (x.Item1.TimeOfDay < timeOfDay || x.Item2.TimeOfDay > timeOfDay)))
		{
			Console.WriteLine(x);
		}
	}
