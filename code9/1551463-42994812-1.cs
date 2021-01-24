    public static char A(string s)
    {
        if (s == null)
            throw new ArgumentNullException("s");
    
        return s.DefaultIfEmpty(' ').First();
    }
