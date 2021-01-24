	static void Main(string[] args)
	{
		Console.WriteLine("ID of thread in 1: {0}",
			Thread.CurrentThread.ManagedThreadId);
		AddAsync();
		Console.ReadLine(); // <-- main thread
	}
