	var speed = new Subject<int>();
	
	IDisposable subscription =
		speed
			.Select(s => Observable.Interval(TimeSpan.FromMilliseconds(s)))
			.Switch()
			.Select((x, n) => n)
			.ObserveOn(Scheduler.Default)
			.Subscribe(x => Console.WriteLine(x));
	
	speed.OnNext(200);
	Thread.Sleep(1000);
	speed.OnNext(1000000); // wait 16.666 minutes
	Thread.Sleep(5000);
	speed.OnNext(20); // stop previous wait
	Thread.Sleep(500);
	subscription.Dispose();
