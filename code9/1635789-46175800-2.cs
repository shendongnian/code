    public static int? GetLastDigits(string text, int maxDigits = int.MaxValue)
    {
        var digits = new Stack<char>();  // Last-in-First-out because we iterate backwards
        for (int i = text.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(text[i]))
                digits.Push(text[i]);
            else if (digits.Count > 0)
                break;
            if (digits.Count == maxDigits)
                break;
        }
        if (digits.Count == 0)
            return null;
        return int.Parse(string.Concat(digits));
    }
