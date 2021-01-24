    var input = "12,3,5,,6,54,127,8,,0,98";
	
	var result = new List<int>();
	var currentNumeric = string.Empty;
	foreach(char c in input)
	{
		if(c == ',' && String.IsNullOrWhiteSpace(currentNumeric))
		{
			result.Add(0);
		}
		else if(c == ',')
		{
			result.Add(int.Parse(currentNumeric));
			currentNumeric = string.Empty;
		}
        else
		{
			currentNumeric += c;
		}
	}
	
	if(!String.IsNullOrWhiteSpace(currentNumeric))
	{
		result.Add(int.Parse(currentNumeric));
	}
