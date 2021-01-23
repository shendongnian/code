	IDisposable subscription =
		Observable
			.Interval(TimeSpan.FromMilliseconds(100.0))
			.Select(n => Application.OpenForms.Count)
			.DistinctUntilChanged()
			.Subscribe(count =>
			{
				/* Changed so do something here */
				Console.WriteLine(count);
			});
