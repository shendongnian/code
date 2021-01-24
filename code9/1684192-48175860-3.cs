	private static string RemoveCharacters(string input, string[] specialCharactersToRemove)
	{
		foreach(string s in specialCharactersToRemove)
        {
            input = input.Replace(s, string.Empty);
        }
		return input;
	}
