    public int CalculateSmsLength(string text)
	{
		if (IsEnglishText(text))
		{
			return text.Length <= 160 ? 1 : Convert.ToInt32(Math.Ceiling(Convert.ToDouble(text.Length) / 153));
		}
		return text.Length <= 70 ? 1 : Convert.ToInt32(Math.Ceiling(Convert.ToDouble(text.Length) / 67));
	}
    public bool IsEnglishText(string text)
    {
        return Regex.IsMatch(text, @"^[\u0000-\u007F]+$");
    }
