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
		
		// Filter the list above to keep only the first list
		// that has the least amount of numbers.
		var filteredCombination = LeastNumbers(combinations);
		
		Console.WriteLine(string.Join("\t", filteredCombination));
	}
	
	public static List<decimal> LeastNumbers(List<List<decimal>> combinations)
	{
		// First get the count for each combination,
		// then get the minimum of those.
		int smallestLength = combinations.Select(l => l.Count).Min();
		
		// Second, get only one of the combinations that have a count
		// equals to the value calculated above.
		return combinations.First(l => l.Count == smallestLength);
	}
