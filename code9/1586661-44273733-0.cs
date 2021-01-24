	Observable
		.FromEventPattern<DataChangedEventArgs>(dataStore, nameof(dataStore.DataChanged))
		.SubscribeOn(TaskPoolScheduler.Default)
		.Select(x => x.EventArgs)
		.StartWith(new DataChangedEventArgs())
		.Throttle(TimeSpan.FromMilliseconds(25))
		.SelectMany(x =>
			Observable.Start(() =>
			{
				Thread.Sleep(5000); // Simulate long-running calculation.
				var result = 42;
				return result;
			}))
		.ObserveOn(new SynchronizationContextScheduler(SynchronizationContext.Current))
		.Subscribe(result =>
		{
			// Do some interesting work with the result.
			// ...
	
			// Do something that makes the DataStore raise another event.
			dataStore.RaiseDataChangedEvent(); // <- DEADLOCK!
		});
