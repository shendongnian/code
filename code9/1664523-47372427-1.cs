    public static string solution(string S)
	{
		var charDict = new Dictionary<char, int>();
		
		foreach (char c in S.Where(c => !char.IsWhiteSpace(c)))
		{
			if(!charDict.TryGetValue(c, out int count))
			{
				charDict[c] = 1;
			}
			charDict[c]++;
			
		}
		
		return charDict.OrderByDescending(kvp => kvp.Value).First().Key.ToString();
	}
