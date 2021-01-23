    class Program
	{
		static void Main()
		{
			new Content().Print().Wait();
			Console.Read();
		}
	}
	class Content
	{
		public async Task<string> Delay1()
		{
			await Task.Delay(5000);
			return "hello";
		}
		public async Task<string> Delay2()
		{
			await Task.Delay(5000);
			return "hello";
		}
		public async Task<string> Delay3()
		{
			await Task.Delay(5000);
			return "hello";
		}
		public async Task Print()
		{
			var tasks = new[] {Delay1(), Delay2(), Delay3()};
			await Task.WhenAll(tasks);
			foreach(var result in tasks.Select(x => x.Result))
			{
				Console.WriteLine(result);
			}
		}
	}
