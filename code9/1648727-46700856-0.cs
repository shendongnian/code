	var myDictionary = new Dictionary<int, List<string>>()
	{
		{ 1, new List<string>() { "Oscar", "Pablo", "John" } },
		{ 2, new List<string>() { "Foo", "Hello", "World" } },
	};
	
	var names = new HashSet<string>() { "John", "Oscar", "Pablo"};
	
	var matchesAll = myDictionary.Values.Where(v => v.All(x => names.Contains(x)));
	var matchesAny = myDictionary.Values.Where(v => v.Any(x => names.Contains(x)));
