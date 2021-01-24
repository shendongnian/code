    // Put this in a static class somewhere.
    public static string FindAny(this string s, params string[] values)
    {
        return values.FirstOrDefault(s.Contains);
    }
