	var arr = new[] { 3, 1, 2, 2, 4 };
	var result = arr.GroupBy(n => n)
                    // Order by the frequency of each group of numbers
					.OrderBy(g => g.Count())
                    // Then by the natural order of each number
					.ThenBy(g => g.Key)
                    // Project the groups back to a flat array
					.SelectMany(g => g);
	
	Console.WriteLine(string.Join(",", result));
    // => 1,3,4,2,2
