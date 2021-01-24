    public static bool TryParseNumeric(string input, out int numeric)
	{
		return int.TryParse(string.Concat(input.Select(c =>
			"+-".Contains(c)
            	? c.ToString()
				: char.GetNumericValue(c).ToString())), out numeric);
	}
