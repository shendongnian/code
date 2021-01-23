    static string firstTwo(string s)
    {
        if (s == null)
        {
            throw new ArgumentNullException("s");
        }
        return s.Substring(0, 2); // without the original check, this line would throw a NullReferenceException if s were null.
    }
