    string g = "<iframe width=\"500\"/>";
	
	string pattern = "width=\"\\d+\"";
	if (Regex.IsMatch(g, pattern))
	{
		string replaced = Regex.Replace(g, pattern, "width=\"100%\"");
		
	}
