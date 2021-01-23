	class Program
	{
		static void Main(string[] args)
		{
			var t = new Timer(doWork, null, 0, 1000);
			
			Console.WriteLine("Press any key to quit");
			Console.ReadKey();
		}
		private static void doWork(object o)
		{
			Console.WriteLine("Thread: {0}", Environment.CurrentManagedThreadId);
			
			// simulate lengthy process
			Thread.Sleep(1000);
		}
	}
