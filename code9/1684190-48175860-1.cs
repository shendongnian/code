	private static string RemoveCharacters(string input, string[] specialCharactersToRemove)
	{
		foreach(string s in specialCharactersToRemove)
        {
            input = input.Replace(s, "");
        }
		return input;
	}
