	ProgressBar[] progressBars = new ProgressBar[] { /* pbs here */ };
	int[] sortedArray = new int[] { 289, 151, 69, 27, 6 };
	var updates = 100;
	Observable
		.Interval(TimeSpan.FromSeconds(5.0 / updates))
		.Take(updates)
		.Select(n => sortedArray.Select(x => x * ((int)n + 1) / updates).ToArray())
		.ObserveOn(this)
		.Subscribe(x =>
		{
			for (var i = 0; i < sortedArray.Length; i++)
			{
				progressBars[i].Value = x[i];
			}
		});
