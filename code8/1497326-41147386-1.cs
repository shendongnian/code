	class ScanClass
	{
		public Subject<Unit> _starter = new Subject<Unit>();
		public Subject<Unit> touchEvents = new Subject<Unit>();
	
		public ScanClass()
		{
			_starter.Select(_ => touchEvents
				.Throttle(TimeSpan.FromSeconds(1))
    //          .Where(e => countOfPointers == expectedFingers.Length)
				.Select(e => new Response())
			)
			.Switch()
			.Subscribe(r => Console.WriteLine("Do Something."));
		}
	public async Task Start()
		{
			_starter.OnNext(Unit.Default);
		}
	}
