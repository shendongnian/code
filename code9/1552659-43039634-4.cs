	public static string ToFormattedString(this decimal d)
	{
		//The comma is not mandatory. but 
		var s = d.ToString();
		var tokens = s.Split(new[]{"."}, StringSplitOptions.RemoveEmptyEntries);
		//if there are no decimal points 12 then there should no be any zeros and periods (.)
		if (tokens.Length == 1)
			return s;
        //I need to remove trailing zeros
		var places = tokens[1].TrimEnd('0');
		if (places.Length == 0)
			return tokens[0];
		//if there is only one decimal point ex- 0.5 then it should be displayed as 0.50 
		if (places.Length == 1)
			return d.ToString("F2");
		var format = string.Format("F{0}", places.Length);
		return d.ToString(format);
	}
