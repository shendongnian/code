    static string TruncateAtNumber(this string s)
    {
        for (int i = 0; i < s.Length; i++)
            if (char.IsDigit(s))
                return s.Substring(0, p).Trim();
        return s;
    }
