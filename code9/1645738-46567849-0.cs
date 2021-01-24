		static void Main(string[] args)
		{
			Task[] tasks = new Task[101];
			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i] = IntenseWork();
			}
			Task.WaitAll(tasks);
			Console.WriteLine("Press Any Key to Continue...");
			Console.ReadKey();
		}
		private static async Task IntenseWork()
		{
			await Task.Delay(5000);
		}
