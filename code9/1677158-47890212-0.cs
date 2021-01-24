	private static int GetMatchScore(string word, string pattern)
	{
		return pattern.TakeWhile((c, i) => i < word.Length && 
                                           Char.ToLower(c) == Char.ToLower(word[i]))
			          .Count();
	}
