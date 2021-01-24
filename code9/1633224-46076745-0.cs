	foreach (var group in query)
	{
		owner = group.Key;
        // for every owner, the status count gets initialized again
		List<KeyValuePair<string, int>> statusCounts = new List<KeyValuePair<string, int>>();
		Console.WriteLine(owner);
		foreach (var o in group.GroupBy(o => o.AdditionalResourcesRequired))
		{
			statusCounts.Add(new KeyValuePair<string, int>(o.Key, o.Count()));
			Console.WriteLine($"\t{o.Key} : {o.Count()}");
		}
		vulnerabilityCounts.Add(new VulnerabilityCount()
		{
			Owner = owner,
			StatusCounts = statusCounts
		});
	}
