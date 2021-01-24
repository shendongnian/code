    public static string Reverse(string s)
    {
        if (s.Length <= 1)
            return s;
        return s[s.Length - 1] + Reverse(s.Substring(0, s.Length - 1));
    }
