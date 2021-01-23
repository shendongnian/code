	string Format(string str, char seperator)
	{
		if (string.IsNullOrEmpty(str))
			return string.Empty;
			
		var sb = new StringBuilder();
		bool previousWasNonAlphaNum = false;
		foreach (var c in str.ToCharArray())
		{
			if (char.IsLetterOrDigit(c))
			{
				if (previousWasNonAlphaNum)
					sb.Append(seperator);
				sb.Append(c);
			}
			previousWasNonAlphaNum = !char.IsLetterOrDigit(c);
		}
		return sb.ToString();
	}
