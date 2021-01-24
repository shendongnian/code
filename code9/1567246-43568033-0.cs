    var Data2 =
        Data.GroupBy(i => new {i.City, i.County, i.Type})
            .Select(group => new {Name = group.Key, Count = group.Count()})
            .OrderBy(x => x.Name)
            .ThenByDescending(x => x.Count)
            .GroupBy(g => new {g.Name.City, g.Name.County})
            .Select(g => g.Select(g2 => 
            	new {Name = new {g.Key.City, g.Key.County, g2.Name.Type}, g2.Count}));
