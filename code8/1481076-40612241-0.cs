	public string Replace(string original, char replacement, params char[] replaceables)
	{
		StringBuilder builder = new StringBuilder(original.Length);
		HashSet<char> replaceable = new HashSet<char>(replaceables);
		foreach(Char character in original)
		{
			if (replaceable.Contains(character))
				builder.Append(replacement);
			else
				builder.Append(character);
		}
		return builder.ToString();
	}
	public string Replace(string original, char replacement, string replaceables)
	{
		return Replace(original, replacement, replaceables.ToCharArray());
	}
