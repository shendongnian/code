	public async Task AwaitEverythingInARxChain()
	{
		IObservable<int> eventSource = Enumerable.Range(1, 10).ToObservable();
	
		await eventSource
			.ObserveOn(Scheduler.Default)
			.Select(id => LoadFromDatabase(id))
			.ObserveOn(DispatcherScheduler.Current)
			.Do(loadedData => UpdateUi(loadedData), () => ShutDownDatabase());
	}
