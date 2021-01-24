	Dictionary<int, List<string>> myDictionary = new Dictionary<int, List<string>>
	{
		{1, new List<string> { "John", "Jane"}},
		{2, new List<string> { "Oscar", "Olivia"}},
		{3, new List<string> { "Pablo", "Paula"}},
		{4, new List<string> { "Steve", "Stella"}},
	};
	var matchedKeys= myDictionary
	.Where(d => d.Value.Any(str => namesToFilter.Contains(str)))
	.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
	
	Console.Write(matchedKeys);
