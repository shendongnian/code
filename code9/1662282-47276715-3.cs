		static public List<string> Normalize2(string input, List<string> dictionary)
		{
			var sorted = dictionary.OrderByDescending( a => a.Length).ToList();
			var results = new List<string>();
			bool found = false;
			
			do
			{
				found = false;
				foreach (var s in sorted)
				{
					if (input.StartsWith(s))
					{
						found = true;
						results.Add(s);
						input = input.Substring(s.Length);
						break;
					}
				}
			}
			while (input != "" && found);
			
			return results;
		}
		public static void Main()
		{
			List<string> dictionary = new List<string>
			{
				"SHORT","LONG","LONGER","FOO","FOOD"
			};
			string input = "FOODSHORTLONGER";
			var normalized = Normalize2(input, dictionary);
			foreach (var s in normalized)
			{
				Console.WriteLine(s);
			}
		}
