	void Test(string myString)
	{
		int a, b, c, d;
		a = b = c = d = 0;
	
		var assign = new Dictionary<string, Action<int>>()
			{
				{ "a", n => a = n },
				{ "b", n => b = n },
				{ "c", n => c = n },
				{ "d", n => d = n },
			};
	
		string[] varNames = { "a", "b", "c", "d" };
		for (int i = 0; i < varNames.Length; i++)
		{
			if (myString.IndexOf(varNames[i]) >= 0)
			{
				assign[varNames[i]](3);
			}
		}
	}
