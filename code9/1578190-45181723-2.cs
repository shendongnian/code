    async Task Main()
    {
         int throttle = 3;
    	var container = new Container();
    
    	container.Results =
    		Enumerable.Range(1, 20)
    		.ToObservable()
    		.Select(n => Observable.FromAsync(() => DoSomething(n)))
    		.Merge(throttle)
    		.Replay();
    		
    	container.Results.Connect();
    
    	(await container.Results).Dump("1");
    	(await container.Results).Dump("2");
    }
    
    public async Task DoSomething(int n)
    {
        Console.WriteLine($"Starting {n}");
        await Task.Delay(100);
    	Console.WriteLine($"Ending {n}");
    }
    
    public class Container
    {
    	public IConnectableObservable<Unit> Results { get; set; }
    }
