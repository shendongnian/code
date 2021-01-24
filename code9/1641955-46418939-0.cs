	private static string ValueToId(int value)
	{
		var parts = new List<string>();
		int numberPart = value % 10000;
		parts.Add(numberPart.ToString("0000"));
		value /= 10000;
		for (int i = 0; i < 3 || value > 0; ++i)
		{
			parts.Add(((char)(65 + (value % 26))).ToString());
			value /= 26;
		}
		return string.Join(string.Empty, parts.AsEnumerable().Reverse().ToArray());
	}
