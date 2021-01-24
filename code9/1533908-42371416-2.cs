    public static IEnumerable<(int Index, string Substring)> GetAllIndicees(this string str, IEnumerable<string> subtrings)
    {
        IEnumerable<(int Index, string Substring)> GetAllIndicees(string substring)
        {
            if (substring.Length > str.Length)
                return Enumerable.Empty<(int, string)>();
            if (substring.Length == str.Length)
                return Enumerable.Repeat((0, str), 1);
            return from start in Enumerable.Range(0, str.Length - substring.Length + 1)
                   where str.Substring(start, substring.Length).Equals(substring)
                   select (start, substring);
        }
        var alloperators = subtrings.SelectMany(s => GetAllIndicees(s));
        return alloperators.Where(o => !alloperators.Except(new[] { o })
                                                    .Any(other => o.Index >= other.Index &&
                                                                  o.Index < other.Index + other.Substring.Length &&
                                                                  other.Substring.Contains(o.Substring)));    
    }
