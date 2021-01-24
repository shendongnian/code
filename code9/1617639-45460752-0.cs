	void Main()
	{
		var taskFactory = new TaskFactory(new LimitedConcurrencyLevelTaskScheduler(8));
		var scheduler = new TaskPoolScheduler(taskFactory);
	
		using (Observable.Timer(TimeSpan.FromMilliseconds(10), scheduler)
			.SelectMany(x => Observable.FromAsync(GetItemsSource))
			.Repeat()
			.ObserveOn(scheduler)
			.Subscribe(async x => await DoSomethingAsync(x.ToList())))
		{
			Console.ReadLine();
		};
	}
	
	private static async Task<IEnumerable<Guid>> GetItemsSource()
	{
		return await Task.Run(() => Enumerable.Range(0, 10).Select(x => Guid.NewGuid()).ToArray());
	}
	
	private static async Task DoSomethingAsync(IEnumerable<Guid> items)
	{
		await Task.Run(() => Console.WriteLine(String.Join("|", items.Select(x => x.ToString()))));
	}
