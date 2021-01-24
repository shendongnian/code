    static string TruncateAtNumber(this string s)
    {
        for (int i = 0; i < s.Length; i++)
            if (char.IsDigit(s[i]))
                return s.Substring(0, i).Trim();
        return s;
    }
