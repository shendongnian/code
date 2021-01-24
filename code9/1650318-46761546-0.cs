	var values = new Dictionary<string, IDictionary<char, string>>
	{
		{
			"test", new Dictionary<char, string>
			{
				['a'] = "apple",
				['b'] = "banana",
				['c'] = "cat"
			}
		},
		{
			"lights", new Dictionary<char, string>
			{
				['c'] = "compact fluorescent",
				['l'] = "light emitting diode",
				['i'] = "incandescent"
			}
		}
	};
	Console.WriteLine(JsonConvert.SerializeObject(values));
