	async Task Main()
	{
		Observable
			.Timer(TimeSpan.FromSeconds(5.0))
			.Subscribe(x => _shuttingDown.OnNext(Unit.Default));
	
		await AwaitEverythingInARxChain();
	}
	
	private Subject<Unit> _shuttingDown = new Subject<Unit>();
	
	public async Task AwaitEverythingInARxChain()
	{
		IObservable<int> eventSource = Observable.Range(0, 10);
	
		await eventSource
			.ObserveOn(Scheduler.Default)
			.Select(id => LoadFromDatabase(id))
			.ObserveOn(DispatcherScheduler.Current)
			.Finally(() => ShutDownDatabase())
			.TakeUntil(_shuttingDown)
			.Do(loadedData => UpdateUi(loadedData));
	}
	
	public int LoadFromDatabase(int x)
	{
		Console.WriteLine("LoadFromDatabase: " + x);
		Thread.Sleep(1000);
		return x;
	}
	
	public void UpdateUi(int x)
	{
		Console.WriteLine("UpdateUi: " + x);
	}
	
	public void ShutDownDatabase()
	{
		Console.WriteLine("ShutDownDatabase");
	}
