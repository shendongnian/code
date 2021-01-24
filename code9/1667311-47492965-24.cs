	private static async Task AddAsync()
	{
		Console.WriteLine("***** Adding with Thread objects *****");
		Console.WriteLine("ID of thread in Main(): {0}",
			Thread.CurrentThread.ManagedThreadId);
		AddParams ap = new AddParams(10, 10);
		var z = Sum(ap); // <-- main thread, z is now the incomplete Sum Task
        await z; // <-- Add a continuation to z
                 //    so that when it finished, it will resume `AddAsync`
                 //    `AddAsync` is "paused" now.
                 //    main thread returns the incomplete Async Task
		Console.WriteLine("Other thread is done!");
	}
