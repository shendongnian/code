    var type2 = type1.GroupBy(i => new { i.City, i.County, i.Type })
            .Select(group => new { Name = group.Key, MyCount = group.Count() })
            .OrderBy(x => x.Name).ThenByDescending(x => x.MyCount)
            .GroupBy(g => new { g.Name.City, g.Name.County })
            .Select(g => g.Select(g2 =>
            new ProcessedType{ Name = new MyType { City = g.Key.City, County = g.Key.County, Type = g2.Name.Type }, MyCount = g2.MyCount })).Take(1000).ToList();
