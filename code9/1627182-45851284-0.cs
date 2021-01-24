	var a =
		Observable
			.Interval(TimeSpan.FromSeconds(1))
			.Select(x => x % 4L)
    		.Scan(long.MinValue, (x, y) => x > y ? x : y)
    		.Publish();
	a.Subscribe(o =>
	{
	    Console.WriteLine(o);
	});
	a.Connect();
