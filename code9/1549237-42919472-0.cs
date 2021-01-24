	public static IEnumerable<string> AlternateCharCases(string lowercaseWord)
	{
		if (lowercaseWord.Length == 1)
		{
			yield return lowercaseWord;
			yield return lowercaseWord.ToUpper();
		}
		else
		{
			foreach (var nested in AlternateCharCases(lowercaseWord.Substring(1)))
			{
				yield return lowercaseWord.Substring(0, 1) + nested;
				yield return lowercaseWord.Substring(0, 1).ToUpper() + nested;
			}
		}
	}
