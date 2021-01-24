	void Main()
	{
		IDisposable subscription =
			Observable
				.Generate(0, x => true, x => x + 1, x => x,
					x => TimeSpan.FromMilliseconds(SpeedVariable))
				.ObserveOn(Scheduler.Default)
				.Subscribe(x => Console.WriteLine(x));
						
		Thread.Sleep(1000);
		SpeedVariable = 1000;
		Thread.Sleep(5000);
		SpeedVariable = 20;
		Thread.Sleep(500);
		subscription.Dispose();
	}
	
	static public volatile int SpeedVariable = 200;
