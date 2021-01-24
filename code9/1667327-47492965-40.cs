	private static async Task AddAsync()
	{
		Console.WriteLine("***** Adding with Thread objects *****");
		Console.WriteLine("ID of thread in Main(): {0}",
			Thread.CurrentThread.ManagedThreadId);
		AddParams ap = new AddParams(10, 10);
		var z = Sum(ap);
        await z;
		Console.WriteLine("Other thread is done!"); // <-- second thread
	}
