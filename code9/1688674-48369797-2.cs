    ....
    var keys = items.Select(t => t.Split(',')[0]).Distinct().ToList();
    foreach (var key in keys)
    {
        var forKey = items.Where(x => x.Split(',')[0] == key)
                          .Select(k => int.Parse(k.Split(',')[1]));
        for (int x = 0; x < forKey.Count(); x += size)
        {
            results.Add(new Results
            {
                Key = key,
                Values = forKey.Skip(x).Take(size).ToList()
            });
        }
    }
    ....
