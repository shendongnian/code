    bool IsMatch(string input, string word)
	{
		var pattern = string.Format("\\b[{0}]+\\b", input);
		var r = new Regex(pattern);
		return r.IsMatch(word);
	}
