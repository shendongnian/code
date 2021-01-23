	Dictionary<string, int> groups = new Dictionary<string, int>();
	foreach (var name in names)
	{
		if (!groups.ContainsKey(name)) groups[name] = 0;
		groups[name]++;
	}
    List<string> mostCommons = new List<string>();
    foreach(var g in groups)
    {
        if(g.Value == groups.Max(y => y.Value)) mostCommons.Add(g.Key);
        else break;
    }
