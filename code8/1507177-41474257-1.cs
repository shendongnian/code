    public int ExtractInteger(string str)
    {
    	var sb = new StringBuilder();
    	for (int i = 0; i < str.Length; i++)
    		if(Char.IsDigit(str[i])) sb.Append(str[i]);
    	return int.Parse(sb.ToString());
    }
