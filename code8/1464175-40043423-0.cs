    var result =
        _db.Clicks
            .GroupBy(m => new {name = m.Name, query = m.Searchquery.Query)
            .Select(g => new {
               Query = g.Key.query,
               Name = g.Key.name,
               Hits = g.Count()
    });
