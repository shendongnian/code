	var myDictionary = new Dictionary<int, List<string>>()
	{
		{ 1, new List<string>() { "Oscar", "Pablo", "John" } },
		{ 2, new List<string>() { "Foo", "Hello", "World" } },
	};
	
	var names = new HashSet<string>() { "John", "Oscar", "Pablo"};
	
	var matchesAll = myDictionary.Values.Where(v => names.All(n => v.Contains(n)));
	var matchesAny = myDictionary.Values.Where(v => names.Any(n => v.Contains(n)));
