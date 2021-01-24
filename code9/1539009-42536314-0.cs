    public static IEnumerable<Item> AddOption(IEnumerable<Item> query, Option options)
    {
        if (string.IsNullOrEmpty(options.English))
            return query;
        if (options.English.StartsWith("^"))
            return query.Where(w => w.English.StartsWith(options.English.Trim().Substring(1)));
        return query = query.Where(w => w.English.Contains(options.English.Trim()));
    }
