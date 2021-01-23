	void RunMe()
	{
		foreach (var threadId in Enumerable.Range(0, 100)
								.AsParallel()
								.WithDegreeOfParallelism(2)
								.Select(x => Thread.CurrentThread.ManagedThreadId)
								.Distinct())
			Console.WriteLine(threadId);
	}
