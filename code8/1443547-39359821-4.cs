	void Main()
	{
		var zero = new System.Drawing.Point(0,0);
		var fenceDistance = 10;
		
		var scheduler = new TestScheduler();
		var source = scheduler.CreateColdObservable(
			ReactiveTest.OnNext(1, new System.Drawing.Point(0,0)),
			ReactiveTest.OnNext(2, new System.Drawing.Point(0,9)),	//Not far enough
			ReactiveTest.OnNext(3, new System.Drawing.Point(0,10)),	//Touches the fence
			ReactiveTest.OnNext(4, new System.Drawing.Point(0,15)),	//Not far enough
			ReactiveTest.OnNext(5, new System.Drawing.Point(0,40))	//Breaches the fence		
			);
	
		var observer = scheduler.CreateObserver<Unit>();
	
		source
			.Scan(Tuple.Create(zero, zero), (acc, cur) =>
			{
				if (DistanceBetween(acc.Item1, cur) >= fenceDistance)
				{
					return Tuple.Create(cur, cur);
				}
				else
				{
					return Tuple.Create(acc.Item1, cur);
				}
			})
			.Where(pair => pair.Item1 == pair.Item2)
			.Select(pair => Unit.Default)
			.Subscribe(observer);
	
	
		scheduler.Start();
		
		ReactiveAssert.AreElementsEqual(new[] {
			ReactiveTest.OnNext(1, Unit.Default),
			ReactiveTest.OnNext(3, Unit.Default),
			ReactiveTest.OnNext(5, Unit.Default)
		},observer.Messages);
		
	}
	
	// Define other methods and classes here
	public static double DistanceBetween(System.Drawing.Point a, System.Drawing.Point b)
	{
		var xDelta = a.X -b.X;
		var yDelta = a.Y - b.Y;
		
		var distanceSqr = (xDelta * xDelta) + (yDelta * yDelta);
		return Math.Sqrt(distanceSqr);
	}
