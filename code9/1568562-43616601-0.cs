	public static void Main()
	{
		
		IAsyncResult result;
		Stopwatch sw = new Stopwatch();
		sw.Start();
		Action action = () =>
		{
			Thread.Sleep(1000);
			//I want to call my function here after 1 second delay
			Console.WriteLine("Delayed logging");
		};
	
		result = action.BeginInvoke(null, null);
		if (result.AsyncWaitHandle.WaitOne(500000))
			Console.WriteLine("Completed");
		else
			Console.WriteLine("done");
			
		sw.Stop();
		Console.WriteLine(sw.ElapsedMilliseconds.ToString());
	}
