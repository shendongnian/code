    public static (IEnumerable<T> Prefixes, IEnumerable<T> suffixes)
        Separate<T>(this IEnumerable<T> source, T splitOn, T resetOn)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));
        var isSuffix = false;
        var prefixes = new List<T>();
        var suffixes = new List<T>();
        foreach (var c in source)
        {
            if (c.Equals(splitOn))
            {
                isSuffix = true;
            }
            else if (c.Equals(resetOn))
            {
                isSuffix = false;
            }
            else
            {
                if (isSuffix)
                {
                    suffixes.Add(c);
                }
                else
                {
                    prefixes.Add(c);
                }
            }
        }
        return (prefixes, suffixes);
    }
