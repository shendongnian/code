	foreach (var group in query)
	{
        // there is no need to keep this outside either
		string owner = group.Key;
        // for every owner, the statusCounts gets initialized again
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
