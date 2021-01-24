    var objects = new List<Dictionary<string, object>>
	{
		new Dictionary<string, object>
		{
			{"name", "Foo"}
		},
		new Dictionary<string, object>
		{
			{"name", "Bar"}
		},
		new Dictionary<string, object>
		{
			{"blah", "Baz"}
		}
	};
    // C# Local function
	IEnumerable<string> GetName(IDictionary<string, object> obj)
	{
        // C# 7 out variable
		if (obj.TryGetValue("name", out var name))
		{
			yield return name as string;
		}
	}
    // ["Foo", "Bar"]
	var names =
		objects
			.SelectMany(GetName)
			.ToList();
