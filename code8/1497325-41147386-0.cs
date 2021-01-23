	async Task Main()
	{
		var sc = new ScanClass();
		sc.Start();
		sc.touchEvents.OnNext(Unit.Default);
		sc.touchEvents.OnNext(Unit.Default);
		sc.Start();
		sc.touchEvents.OnNext(Unit.Default);
		sc.touchEvents.OnNext(Unit.Default);
		await Task.Delay(TimeSpan.FromSeconds(1));
	}
	
	// Define other methods and classes here
	class ScanClass
	{
		IObservable<Response> _scanSlapObservable;
		public Subject<Unit> _interrupter = new Subject<Unit>();
		public Subject<Unit> touchEvents = new Subject<Unit>();
	
		public async Task Start()
		{
			_interrupter.OnNext(Unit.Default);
	
			_scanSlapObservable = touchEvents
							.Throttle(TimeSpan.FromSeconds(1))
	//						.Where(e => countOfPointers == expectedFingers.Length)
							.Select(e => new Response())
							.TakeUntil(_interrupter)
							.FirstOrDefaultAsync();
	
			Response response = await _scanSlapObservable;
			if (response != null)
			{
				//do something
				Console.WriteLine("Do Something");
			}
			else
			{
				Console.WriteLine("Null Response");
			}
		}
	}
	class Response { }
