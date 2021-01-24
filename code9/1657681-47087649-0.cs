	Stopwatch sw = Stopwatch.StartNew();
	IDisposable subscription = query.Subscribe(u => { }, () =>
	{
		Console.WriteLine("All Done in {0} seconds.", sw.Elapsed.TotalSeconds);
	});
