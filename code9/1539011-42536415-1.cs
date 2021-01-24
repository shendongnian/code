    var lookup = new Dictionary<bool, Func<Options, bool>>() {
        { true, w => w.English.StartsWith(options.English.Trim().Substring(1)) },
        { false, w => w.English.Contains(options.English.Trim())} };
    if (options.English != null && options.English != "")
    {
        query = query.Where(lookup[options.English.StartsWith("^")]);
    }
