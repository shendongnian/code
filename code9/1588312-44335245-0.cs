		static void Main(string[] args)
		{
			Task task1 = DoAsync();
			Task task2 = DoAsync();
			Task task3 = DoAsync();
			Task.WaitAll(task1, task2, task3);
		}
		private static int TaskId = 1;
		private static async Task DoAsync()
		{
			int Id = TaskId++;
			await Task.Yield();
			Console.WriteLine("Press key");
			Console.ReadKey();
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine(string.Format("Task {0}: {1}", Id, i));
				await Task.Delay(1000);
			}
		}
