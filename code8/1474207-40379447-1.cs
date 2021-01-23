	public bool ContainsVowel(string word)
	{
		if (string.IsNullOrEmpty(word))
		{
			return false;
		}
		
		var upperCaseCharacters = word.ToUpper().ToCharArray();
		
		foreach (var character in upperCaseCharacters)
		{
			switch (character)
			{
				case 'A':
				case 'E':
				case 'I':
				case 'O':
				case 'U':
					return true;
					break;
			}
		}
		
		return false;
	}
