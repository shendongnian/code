    while (true)
    {
    	using (var mutex = new Mutex(false, "THIS_IS_THE_UNIQUE_NAME_OF_THE_MUTEX"))
    	{
    		if (!mutex.WaitOne(0))
    		{
    			Console.WriteLine($"Process {Process.GetCurrentProcess().Id} waits");
    			mutex.WaitOne();
    		}
    		Console.Write($"Process {Process.GetCurrentProcess().Id} has entered protected area...");
    
    		Thread.Sleep(1000); // simulate work
    
    		Console.WriteLine("and is about to leave!");
    		mutex.ReleaseMutex();
    	}
    }
