	var subscription = subject
		.Window(TimeSpan.FromSeconds(1))
		.Select(o => o.Distinct())
		.Merge()
		.Subscribe(eg =>
			{
				eg.Dump();
			});
