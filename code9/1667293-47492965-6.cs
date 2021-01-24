	private static async Task AddAsync() // <-- called from `AddAsync()`
	{
		Console.WriteLine("***** Adding with Thread objects *****"); // <-- main thread
		Console.WriteLine("ID of thread in Main(): {0}",
			Thread.CurrentThread.ManagedThreadId); // <-- main thread
		AddParams ap = new AddParams(10, 10); // <-- main thread
        var z = Sum(ap); // <-- shenanigans!!!
		await z;
		Console.WriteLine("Other thread is done!");
	}
