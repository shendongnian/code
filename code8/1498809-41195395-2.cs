    void Main()
    {
    	System.Threading.Timer timer = new Timer((x) =>
    	{
    		Console.WriteLine($"{DateTime.Now.TimeOfDay} - Is Thread Pool Thread: {Thread.CurrentThread.IsThreadPoolThread} - Managed Thread Id: {Thread.CurrentThread.ManagedThreadId}");
    		Thread.Sleep(5000);
    
    	}, null, 1000, 1000);
    	
    	Console.ReadLine();
    }
