    private static readonly HashSet<char>  charSet
      = new HashSet<char>("ABCDEFabcdef0123456789");
    static bool IsHexNumber(string s)
    {
        return s.All(c => charSet.Contains(c));
    }
    
