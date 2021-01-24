	var items = Enumerable.Range(0, 50);
	var parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = 3 };
	Parallel.ForEach(items, parallelOptions,
		i =>
		{
			Task.Delay(1000).GetAwaiter().GetResult(); // It's just an example 
			Console.WriteLine($"{DateTime.Now.ToLongTimeString()} I'm {i}");
		});
