	class Program
	{
		static void Main(string[] args)
		{
			var someLongDataString = "";
			var builder = new StringBuilder(); <---- use a StringBuilder instead
			const int sLen = 30, loops = 50000;
			var source = new string('X', sLen);
			var stopwatch = Stopwatch.StartNew();
			Console.WriteLine();
			for (var i = 0; i < loops; i++)
			{
				//someLongDataString += source;
				builder.Append(source);
			}
			someLongDataString = builder.ToString();
			Console.WriteLine("Elapsed: {0}", stopwatch.Elapsed);
			Console.WriteLine("Press any key");
			Console.ReadLine();
		}
	}
