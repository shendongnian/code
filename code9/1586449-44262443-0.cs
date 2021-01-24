	var map = new Dictionary<string, VariableType>()
	{
		{ "int", VariableType.INT },
		{ "bool", VariableType.BOOL },
	};
	var variables =
		XDocument
			.Load("fname")
			.Root
			.Elements("variable")
			.Select(x => new Variable()
			{
				varName = x.Element("varName").Value,
				type = map[x.Element("type").Value.ToLower()],
				value = x.Element("value").Value,
			})
			.ToList();
