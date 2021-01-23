	string GroupsOfThree(string str)
	{
		StringBuilder sb = new StringBuilder();
		
		for (int i = 0; i + 2 < str.Length; i += 3)
		{
			string sub = str.Substring(i, 3);
			if (sub.All(c => c == sub[0]))
				sb.Append("+");
			else
				sb.Append(sub);
		}
		
		return sb.ToString();
	}
