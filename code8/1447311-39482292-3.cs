    public async Task TestMethod1()
    {
    	TestContext.WriteLine("Starting test...");
    	var observable = Observable.Create<int>(async ob =>
    	{
    		ob.OnNext(1);
    		await Task.Delay(1000);
    		ob.OnNext(2);
    		await Task.Delay(1000);
    		ob.OnNext(3);
    		ob.OnCompleted();
    	});
    
    	observable.Subscribe(i => TestContext.WriteLine($"Sync {i}"));
    	var selectManyObservable = observable.SelectMany(i => WriteAsync(i).ToObservable()).Publish().RefCount();
    	selectManyObservable.Subscribe();
    	await selectManyObservable.LastOrDefaultAsync();
    	TestContext.WriteLine("Complete.");
    }
