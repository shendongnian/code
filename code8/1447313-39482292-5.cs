    public void TestMethod1()
    {
    	TestContext.WriteLine("Starting test...");
    	var observable = Observable.Concat<int>(
    		Observable.Return(1),
    		Observable.Empty<int>().Delay(TimeSpan.FromSeconds(1)),
    		Observable.Return(2),
    		Observable.Empty<int>().Delay(TimeSpan.FromSeconds(1)),
    		Observable.Return(3)
        );
    	
		var syncOutput = observable
			.Select(i => $"Sync {i}");
		syncOutput.Subscribe(s => TestContext.WriteLine(s));
		
		var asyncOutput = observable
			.SelectMany(i => WriteAsync(i, scheduler));
		asyncOutput.Subscribe(s => TestContext.WriteLine(s), () => TestContext.WriteLine("Complete."));
    }
    
    public IObservable<string> WriteAsync(int value, IScheduler scheduler)
    {
    	return Observable.Return(value)
    		.Delay(TimeSpan.FromSeconds(1), scheduler)
    		.Select(i => $"Async {value}");
    }
    
    public static class TestContext
    {
    	public static void WriteLine(string s)
    	{
    		Console.WriteLine(s);
    	}
    }
