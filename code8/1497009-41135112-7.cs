	public static IEnumerable<string> GetAllSubStrings(string input, int length)
	{
		for(var i = 0; i < input.Length - length + 1; i++)
		{
			yield return input.Substring(i, length);
		}
	}
