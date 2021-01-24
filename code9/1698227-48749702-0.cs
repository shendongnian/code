    var namelist = json_converted
        .GroupBy(n => string.Join("|", n.names.OrderBy(s => s)))
        .Select(g => new {
            Name = g.First().names
        ,   Count = g.Count()
        });
