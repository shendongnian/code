    public string UseCommasForDecimals(string input)
    {
    	string[] split = input.Split(',', '.');
    	var fraction = split.Last();
    	var wholeNumber = string.Join(".", split.Take(split.Length - 1));
    	if (wholeNumber.Length == 0)
    	{
    		wholeNumber = "0";
    	}
    	return wholeNumber + "," + fraction;
    }
