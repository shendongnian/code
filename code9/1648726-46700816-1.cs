	Dictionary<int, List<string>> myDictionary = new Dictionary<int, List<string>>
	{
		{1, new List<string> { "John", "Oscar", "Pablo"}},
		{2, new List<string> { "Oscar", "Olivia"}},
		{3, new List<string> { "Pablo", "Paula"}},
		{4, new List<string> { "Steve", "Stella"}},
	};
	var matchedKeys= myDictionary
	.Where(d => namesToFilter.Where(str => d.Value.Any(v => v == str)).Count() == namesToFilter.Count())
	.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
	
	Console.Write(matchedKeys);
