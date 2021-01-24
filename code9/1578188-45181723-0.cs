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
    
        var res = await container.Results;
    	
    	res.Dump("Res");
    }
    
    public async Task DoSomething(int n)
    {
        Console.WriteLine($"Starting {n}");
        await Task.Delay(100);
    	Console.WriteLine($"Ending {n}");
    }
    
    public class Container
    {
    	public IObservable<Unit> Results { get; set; }
    }
