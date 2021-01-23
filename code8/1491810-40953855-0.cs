		const string RegXPattern = @"(?i):/api/(?<controller>\w+)/(?<action>\w+)/?$";
		static Regex regex = new Regex(RegXPattern, RegexOptions.Compiled);
		static void Main(string[] args)
		{
			const string InputToMatch = "/API/person/load";
			regex.IsMatch(InputToMatch); // Warmup
			var sw = Stopwatch.StartNew();
			for (int i = 0; i < 10000000; i++)
			{
				var match = regex.IsMatch(InputToMatch, 0);
			}
			sw.Stop();
			Console.WriteLine(sw.Elapsed.ToString());
			Console.ReadLine();
		}
