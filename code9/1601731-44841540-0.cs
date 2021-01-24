	Func<Action, int, TimeSpan> measure = (a, c) =>
	{
		var sw = Stopwatch.StartNew();
		for (var i = 0; i < c; i++)
		{
			a();
		};
		sw.Stop();
		return sw.Elapsed;
	};
	var listOfInts = new List<int>
	{
		1, 2, 3, 4, 5,
		6, 7, 8, 9, 10
	};
	int? value;
	
	Action indexed = () =>
	{
		value = listOfInts[0];
	};
	
	Action first = () =>
	{
		value = listOfInts.First();
	};	
	
	// warm up runs
	measure(indexed, 1);
	measure(first, 1);
	
	var measurements =
		Enumerable
			.Range(0, 10) // run 10 separate tests
			.Select(x => new
			{
				indexed = measure(indexed, 1000000), // 1M iterations
				first = measure(first, 1000000), // 1M iterations
			})
			.ToArray();
	Console.WriteLine(measurements.Select(x => x.indexed.TotalMilliseconds).Average());
	Console.WriteLine(measurements.Select(x => x.first.TotalMilliseconds).Average());
