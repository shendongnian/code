    async Task Go()
    {
    	
    	var o = Observable.Interval(TimeSpan.FromMilliseconds(100));
    	var d = o
    		.Subscribe(i => Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {i}"))
    		.ToAsync(async () =>
    		{
    			Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Dispose Beginning");
    			await Task.Delay(1000);
    			Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Dispose Complete");
    		});
    	Console.Read();
    	var t = d.DisposeAsync();
    	Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Outside task, waiting for dispose to complete");
    	await t;
    	Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Task Complete");
    
    }
