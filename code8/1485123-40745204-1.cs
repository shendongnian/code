	void Main()
	{	
		var sw = Stopwatch.StartNew();
		Seq();
		sw.Stop();
		Console.WriteLine($"Seq {sw.Elapsed}");
	
	
		sw = Stopwatch.StartNew();
		Parallel1();
		sw.Stop();
		Console.WriteLine($"Parallel1 {sw.Elapsed}");
	
	
		sw = Stopwatch.StartNew();
		Parallel2();
		sw.Stop();
		Console.WriteLine($"Parallel2 {sw.Elapsed}");
	}
