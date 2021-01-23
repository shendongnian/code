	Observable
		.Start(() => manager.Get(), Scheduler.Default)
		.Merge()
		.ObserveOnDispatcher()
		.SubscribeOn(new NewThreadScheduler())
		.Subscribe(result =>
		{
			Data.Add(result);
		});
