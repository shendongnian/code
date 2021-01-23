    if (options.English != null) 
    {
        bool englishStartsWith = options.English.StartsWith("^");
        if(englishStartsWith)
        {
           query = query.Where(w => w.English.StartsWith(options.English.Substring(1)));
        }
        else
        {
           query = query.Where(w => w.English.Contains(options.English));
        }
    }
                
