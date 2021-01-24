	// Synchronous method.
	static void Main(string[] args)
	{
		// Call async methods, but don't await them until needed.
		Task<string> task1 = DoAsync();
		Task<string> task2 = DoAsync();
		Task<string> task3 = DoAsync();
		// Do other stuff.
		// Now, it is time to await the async methods to finish.
		Task.WaitAll(task1, task2, task3);
		// Do something with the results.
		Console.WriteLine(task1.Result);
		Console.ReadKey();
	}
	private static async Task<string> DoAsync()
	{
		Console.WriteLine("Started");
		await Task.Delay(3000);
		Console.WriteLine("Finished");
		return "Success";
	}
		
	// Output:
	// Started
	// Started
	// Started
	// Finished
	// Finished
	// Finished
	// Success
