    public static string TakeUntil(this string s, string search)
    {
        if (string.IsNullOrEmpty(s)) return s;
        var pos = s.IndexOf(search, StringComparison.OrdinalIgnoreCase);
        if (pos >= 0)
            return s.Substring(0, pos);
        return s;
    }
    public static string TakeUntilLast(this string s, string search)
    {
        if (string.IsNullOrEmpty(s)) return s;
        var pos = s.LastIndexOf(search, StringComparison.OrdinalIgnoreCase);
        if (pos >= 0)
            return s.Substring(0, pos);
        return s;
    }
    
    public static string TakeFrom(this string s, string search)
    {
        if (string.IsNullOrEmpty(s)) return s;
        var pos = s.IndexOf(search, StringComparison.OrdinalIgnoreCase);
        if (pos >= 0)
            return s.Substring(pos + search.Length);
        return s;
    }
    public static string TakeFromLast(this string s, string search)
    {
        if (string.IsNullOrEmpty(s)) return s;
        var pos = s.LastIndexOf(search, StringComparison.OrdinalIgnoreCase);
        if (pos >= 0)
            return s.Substring(pos + search.Length);
        return s;
    }
