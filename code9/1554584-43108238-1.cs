    var flat = data
        .GroupBy(item => item.Column1)
        .Select(g => new {
            Column1 = g.Key
        ,   Dict = g.ToDictionary(r => r.Column2, r => r.Column3)
        }).ToList();
