    var result = dt1.AsEnumerable()
        .GroupBy(x => new { Country = x.Field<string>("Country"), City = x.Field<string>("City") })
        .SelectMany(group => group
            .Select((row, index) => new { Row = row, Index = index })
            .GroupBy(x => x.Index / 3)
            .Select(g => new
            {
                Agents = string.Join(",", g.Select(x => x.Row.Field<string>("Agent"))),
                group.Key.Country, group.Key.City
            }));
