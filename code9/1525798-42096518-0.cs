    var res = congigs
        .GroupBy(c => new {c.Id, c.Name})
        .Select(g =>
            new Configuration {
                Id = g.Key.Id
            ,   Name = g.Key.Name
            ,   Objects = g
                   .SelectMany(c => c.Objects)
                   .GroupBy(c => c.Code)
                   .Select(gg => gg.First())
            }
        ).ToList();
