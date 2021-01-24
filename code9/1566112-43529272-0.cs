	string result = String.Empty;
	for (int i = 0; i < s.Length; i++)
	{
		char c = s[i];
		result += char.ToUpper(c);
		result += new String(char.ToLower(c), i);
		if (i < s.Length - 1)
		{
			result += "-";
		}
	}
