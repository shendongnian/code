	public void TestMethod1()
	{
		var scheduler = new TestScheduler();
		TestContext.WriteLine("Starting test...");
		var observable = Observable.Concat<int>(
			Observable.Return(1),
			Observable.Empty<int>().Delay(TimeSpan.FromSeconds(1), scheduler),
			Observable.Return(2),
			Observable.Empty<int>().Delay(TimeSpan.FromSeconds(1), scheduler),
			Observable.Return(3)
	    );
		
		var syncOutput = observable
			.Select(i => $"Sync {i}");
		syncOutput.Subscribe(s => TestContext.WriteLine(s));
		
		var asyncOutput = observable
			.SelectMany(i => WriteAsync(i, scheduler));
		asyncOutput.Subscribe(s => TestContext.WriteLine(s), () => TestContext.WriteLine("Complete."));
	
		var asyncExpected = scheduler.CreateColdObservable<string>(
			ReactiveTest.OnNext(1000.Ms(), "Async 1"),
			ReactiveTest.OnNext(2000.Ms(), "Async 2"),
			ReactiveTest.OnNext(3000.Ms(), "Async 3"),
			ReactiveTest.OnCompleted<string>(3000.Ms() + 1) //+1 because you can't have two notifications on same tick
		);
	
		var syncExpected = scheduler.CreateColdObservable<string>(
			ReactiveTest.OnNext(0000.Ms(), "Sync 1"),
			ReactiveTest.OnNext(1000.Ms(), "Sync 2"),
			ReactiveTest.OnNext(2000.Ms(), "Sync 3"),
			ReactiveTest.OnCompleted<string>(2000.Ms()) //why no +1 here?
		);
	
		var asyncObserver = scheduler.CreateObserver<string>();
		asyncOutput.Subscribe(asyncObserver);
		var syncObserver = scheduler.CreateObserver<string>();
		syncOutput.Subscribe(syncObserver);
		scheduler.Start();
		ReactiveAssert.AreElementsEqual(
			asyncExpected.Messages,
			asyncObserver.Messages);
	
		ReactiveAssert.AreElementsEqual(
			syncExpected.Messages,
			syncObserver.Messages);
	}
	
    public static class MyExtensions
    {
    	public static long Ms(this int ms)
    	{
    		return TimeSpan.FromMilliseconds(ms).Ticks;
    	}
    
    }
