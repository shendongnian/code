    public static string MyReverse(string s)
    {
        if (s.Length == 1)
        {
            return s;
        }
        var firstLetter = s[0];
        return MyReverse(s.Substring(1)) + firstLetter;
    }
`
