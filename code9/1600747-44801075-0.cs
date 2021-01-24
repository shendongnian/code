    public int CalculateSmsLength(string text)
	{
		if (IsEnglishText(text))
		{
			if (text.Length <= 160)
				return 1;
			return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(text.Length) / 153));
		}
		if (text.Length <= 70)
			return 1;
		return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(text.Length) / 67));
	}
    public static bool IsEnglishText(string text)
    {
        return Regex.IsMatch(text, @"^[\u0000-\u007F]+$");
    }
