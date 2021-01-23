	var result = arr.GroupBy(n=> n)
                    .Select(group => new
                    {
                        Number = group.Key,
                        Count = group.Count()
                    })
					.OrderBy(group => group.Count)
					.ThenBy(group => group.Number)
					.SelectMany(group => Enumerable.Repeat(group.Number, group.Count));
	
	Console.WriteLine(string.Join(",", result));
    // => 1,3,4,2,2
