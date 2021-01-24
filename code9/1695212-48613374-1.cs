    static string TruncateAtNumber(this string s)
    {
        int p = -1;
        for (int i = 0; i < s.Length; i++)
            if (char.IsDigit(s)) { p = i; break; }
        return (p < 0 ? s : s.Substring(0, p).Trim());
    }
