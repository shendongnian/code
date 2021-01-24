	var speed = new ReplaySubject<int>(1);
	
	IDisposable subscription =
		Observable
			.Generate(0, x => true, x => x + 1, x => x,
				x => TimeSpan.FromMilliseconds(speed.MostRecent(200).First()))
			.ObserveOn(Scheduler.Default)
			.Subscribe(x => Console.WriteLine(x));
		
	Thread.Sleep(1000);
	speed.OnNext(1000);
	Thread.Sleep(5000);
	speed.OnNext(20);
	Thread.Sleep(500);
	subscription.Dispose();
