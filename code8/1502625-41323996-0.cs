    foreach (my_object m in Source)
    {
        List<string> all = m.Column1.Union(m.Column2)
                                    .Union(m.Column3)
                                    .Union(m.Column4)
                                    .ToList();
        bool exists = all.Any(x => searchWords.Contains(x));    
        if(exists)
            results.Add(m); 
    }
