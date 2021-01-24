	var source = new Subject<string>();
	source
		.Select((item, index) => (item, index)) //index only required for logging purposes. 
		.OrderedSelectMany(async t =>
		{
			var item = t.Item1;
			var index = t.Item2;
			Console.WriteLine($"Starting item {item}, index {index}.");
			switch (index)
			{
				case 0:
					await Task.Delay(TimeSpan.FromMilliseconds(50));
					Console.WriteLine($"Completing item {item}, index {index}.");
					return (item, index);
				case 1:
					await Task.Delay(TimeSpan.FromMilliseconds(200));
					Console.WriteLine($"Completing item {item}, index {index}.");
					return (item, index);
				case 2:
					await Task.Delay(TimeSpan.FromMilliseconds(20));
					Console.WriteLine($"Completing item {item}, index {index}.");
					return (item, index);
				default:
					throw new NotImplementedException();
			}
		})
		.Subscribe(s => Console.WriteLine($"Received item '{s}'."));
		
	source.OnNext("A");
	source.OnNext("B");
	source.OnNext("C");
	source.OnCompleted();
