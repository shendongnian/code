    public static int? GetLastDigits(string text)
    {
        var digits = new List<char>();
        for (int i = text.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(text[i]))
                digits.Add(text[i]);
            else if (digits.Count > 0)
                break;
        }
        if (digits.Count == 0)
            return null;
        digits.Reverse()
        return int.Parse(string.Concat(digits));
    }
