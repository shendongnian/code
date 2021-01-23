    foreach (my_object m in Source)
    {
        List<string> all = m.Column1.Union(m.Column2)
                                    .Union(m.Column3)
                                    .Union(m.Column4)
                                    .ToList();
        bool exists = SearchWords.Any(x => all.IndexOf(x) != -1));    
        if(exists)
            results.Add(m); 
    }
