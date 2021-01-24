	BlockingCollection<int> bc = new BlockingCollection<int>();
	
	async Task Main()
	{
        // Fire up two readers
		Task.Run(() => ReadCollection1());
		Task.Run(() => ReadCollection2());
		
        // Add items to process.
		bc.Add(5);
		bc.Add(6);
		bc.Add(7);
		bc.Add(8);
		bc.Add(9);
		
		bc.CompleteAdding(); // Signal we are finished adding items (on close of application for example)
	}
	
	void ReadCollection1()
	{
		foreach (var item in bc.GetConsumingEnumerable()) 
		{
			$"1 processed {item}".Dump();
		}
	}
	
	
	void ReadCollection2()
	{
		foreach (var item in bc.GetConsumingEnumerable()) 
		{
			$"2 processed {item}".Dump();
		}
	}
