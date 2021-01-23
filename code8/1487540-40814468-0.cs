    async Task Main()
    {
    	Console.WriteLine("Starting A now.");
    	GetResult();
    	Console.WriteLine("Finished A now.");
    
    	Console.WriteLine("Starting B now.");
    	await GetResult();
    	Console.WriteLine("Finished B now.");
    
    	Console.WriteLine("Starting C now.");
    	GetResultAync();
    	Console.WriteLine("Finished C now.");
    
    	Console.WriteLine("Starting D now.");
    	await GetResultAync();
    	Console.WriteLine("Finished D now.");
    }
    
    Task GetResult()
    {
    	return Task.Delay(5000).ContinueWith(a => Console.WriteLine("Finished!"));
    }
    
    async Task GetResultAync()
    {
    	await Task.Delay(5000).ContinueWith(a => Console.WriteLine("Finished!"));
    }
