    Array.ForEach(Directory.GetFiles(@"c:\temp\output\"), File.Delete);
    
    Stopwatch timer = new Stopwatch();
    timer.Start();
    int numberOfThreads = 8;
    var clonedZipEntries = new List<ReadOnlyCollection<ZipArchiveEntry>>();
    
    for (int i = 0; i < numberOfThreads; i++)
    {
    	clonedZipEntries.Add(ZipFile.Open(@"c:\temp\temp.zip", ZipArchiveMode.Read).Entries);
    }
    int totalZipEntries = clonedZipEntries[0].Count;
    int numberOfEntriesPerThread = totalZipEntries / numberOfThreads;
    
    Func<object,int> action = (object thread) =>
    {
    	int threadNumber = (int)thread;
    	int startIndex = numberOfEntriesPerThread * threadNumber;
    	int endIndex = startIndex + numberOfEntriesPerThread;
    	if (endIndex > totalZipEntries) endIndex = totalZipEntries;
    
    	for (int i = startIndex; i < endIndex; i++)
    	{
    		Console.WriteLine($"Extracting {clonedZipEntries[threadNumber][i].Name} via thread {threadNumber}");
    		clonedZipEntries[threadNumber][i].ExtractToFile($@"C:\temp\output\{clonedZipEntries[threadNumber][i].Name}");
    	}
    
    	//Check for any remainders due to non evenly divisible size
    	if (threadNumber == numberOfThreads - 1 && endIndex < totalZipEntries)
    	{
    		for (int i = endIndex; i < totalZipEntries; i++)
    		{
    			Console.WriteLine($"Extracting {clonedZipEntries[threadNumber][i].Name} via thread {threadNumber}");
    			clonedZipEntries[threadNumber][i].ExtractToFile($@"C:\temp\output\{clonedZipEntries[threadNumber][i].Name}");
    		}
    	}
    	return 0;
    };
    
    
    //Construct the tasks
    var tasks = new List<Task<int>>();
    for (int threadNumber = 0; threadNumber < numberOfThreads; threadNumber++) tasks.Add(Task<int>.Factory.StartNew(action, threadNumber));
    
    Task.WaitAll(tasks.ToArray());
    timer.Stop();
    
    var threaderTimer = timer.ElapsedMilliseconds;
    
    
    
    Array.ForEach(Directory.GetFiles(@"c:\temp\output\"), File.Delete);
    
    timer.Reset();
    timer.Start();
    var entries = ZipFile.Open(@"c:\temp\temp.zip", ZipArchiveMode.Read).Entries;
    foreach (var entry in entries)
    {
    	Console.WriteLine($"Extracting {entry.Name} via thread 1");
    	entry.ExtractToFile($@"C:\temp\output\{entry.Name}");
    }
    timer.Stop();
    
    Console.WriteLine($"Threaded version took: {threaderTimer} ms");
    Console.WriteLine($"Non-Threaded version took: {timer.ElapsedMilliseconds} ms");
    
    
    Console.ReadLine();
