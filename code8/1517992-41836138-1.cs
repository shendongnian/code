	var arr = new[] { 3, 1, 2, 2, 4};
	var result = arr.GroupBy(n => n)
                    // Project to a list of { number, count }
                    .Select(group => new
                    {
                        Number = group.Key,
                        Count = group.Count()
                    })
                    // Order the intermediate list by count
					.OrderBy(group => group.Count)
                    // Project to a flat array of numbers
					.SelectMany(group => Enumerable.Repeat(group.Number, group.Count));
	
	Console.WriteLine(string.Join(",", result));
    // => 3,1,4,2,2
