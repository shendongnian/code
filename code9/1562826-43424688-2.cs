	public static void Main()
	{
	    // Here I have hard-coded all the combinations,
		// but in real life you would calculate them.
		// Probably using your `Solver` or any of the answers in this page.
		var combinations = new List<List<decimal>>{
			new List<decimal>{ 1, 2, 3, 4, 5 },
			new List<decimal>{ 1, 2, 5, 7 },
			new List<decimal>{ 1, 3, 4, 7 },
			new List<decimal>{ 1, 3, 5, 6 },
			new List<decimal>{ 2, 3, 4, 6 },
			new List<decimal>{ 2, 6, 7 },
			new List<decimal>{ 3, 5, 7 },
			new List<decimal>{ 4, 5, 6 }
		};
		
		// This must be known before hand.
		// That's why I think my first solution is more usefull.
		int max = 3;
		
		// Filter the list above to keep only the lists
		// that have a count less or equal to a predetermined maximum.
		var filteredCombinations = FilterByMaxLength(combinations, max);
		
		foreach (var combination in filteredCombinations)
		{
			Console.WriteLine(string.Join("\t", combination));
		}
	}
	
	public static List<List<decimal>> FilterByMaxLength(List<List<decimal>> combinations, int max)
	{
		return combinations.Where(l => l.Count <= max).ToList();
	}
