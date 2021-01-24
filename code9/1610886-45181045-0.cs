	Observable
		.FromEventPattern<EventArgs>(_listener, "EventHandler", System.Reactive.Concurrency.NewThreadScheduler.Default)
		.GroupBy(x => x.EventArgs.Key)
		.Select(g => g.Sample(TimeSpan.FromSeconds(1.0)))
		.Merge()
		.Subscribe(x =>
		{
			updateSubject.OnNext(key);
		});
