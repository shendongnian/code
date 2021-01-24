    if (string.IsNullOrEmpty(options.English))
        { /* do nothing */ }
    else if (options.English.StartsWith("^"))
        {
            query = query.Where(w => w.English.StartsWith(options.English.Trim().Substring(1)));
        }
    else
        {
            query = query.Where(w => w.English.Contains(options.English.Trim()));
        }
