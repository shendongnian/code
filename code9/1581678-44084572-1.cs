	class Program
	{
		public static void Main()
		{
			const string search = "Bob";
			var matcher = new Matcher();
			var items = new List<Tables>
			{
				new Tables {Content = string.Empty, Name = "Bob"}, //This will match
				new Tables {Content = "Bob is the best guy.", Name = "Joe"}, //This will also match
				new Tables {Content = "Something", Name = null} // This won't null name to verify that nothing unexpected will happen
			};
			
			var results = matcher.FilterResult( search, items );
			foreach ( var result in results )
			{
				Console.WriteLine($"Matched the guy named {result.Name}");
			}
			Console.ReadKey();
		}
	}
