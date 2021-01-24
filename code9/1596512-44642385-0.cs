	IDisposable subscription =
		Observable
			.Generate(0, x => true, x => x + 1, x => x,
				x => TimeSpan.FromMilliseconds(SpeedVariable))
			.ObserveOnDispatcher()
			.Subscribe(x =>
			{
				//Some number generated and set to a property
			});
