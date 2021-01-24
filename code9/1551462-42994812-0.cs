    public static string A(string s)
    {
        if (s == null)
            throw new ArgumentNullException("s");
    
        return s.DefaultIfEmpty(' ').First().ToString();
    }
