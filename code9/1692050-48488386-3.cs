	async Task Main()
	{
		// Create list of work to do later
		var tasks = new List<Func<Task>>();
		
		// Schedule some work
		tasks.Add(() => DoTaskWork(1));
		tasks.Add(() => DoTaskWork(2));
		
		// Wait for user input before doing work to demonstrate they are not started right away
		Console.ReadLine();
		
		// Execute and wait for the completion of the work to be done
		await Task.WhenAll(tasks.Select(t => t.Invoke()));
        Console.WriteLine("Ready");
	}
	
	public async Task DoTaskWork(int taskNr)
	{
	    await Task.Delay(100);
		Console.WriteLine(taskNr);
	}
