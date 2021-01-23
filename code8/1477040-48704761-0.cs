        static void Main(string[] args)
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(10 - i);
				Thread.Sleep(1000);
			}
			Console.WriteLine(Assembly.GetExecutingAssembly().Location);
			Console.WriteLine(Directory.GetCurrentDirectory());
			Console.ReadLine();
		}
