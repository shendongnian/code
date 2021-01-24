	public static void Main()
	{
	    // Here I have hard-coded all the combinations,
		// but in real life you would calculate them.
		// Probably using your `Solver` or any of the other answers in this page.
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
		
		// Filter the list above to keep only the lists
		// that have the least amount of numbers.
		var filteredCombinations = LeastNumbers(combinations);
		
		foreach (var combination in filteredCombinations)
		{
			Console.WriteLine(string.Join("\t", combination));
		}
	}
	
	public static List<List<decimal>> LeastNumbers(List<List<decimal>> combinations)
	{
		// First get the count for each combination, then get the minimum of those.
		int smallestLength = combinations.Select(l => l.Count).Min();
		
		// Second, only keep those combinations which have a count equals to the value calculated above.
		return combinations.Where(l => l.Count == smallestLength).ToList();
	}
