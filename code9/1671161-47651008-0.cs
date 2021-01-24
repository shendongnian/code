    var newSort = dtFinal.AsEnumerable()
        .GroupBy(row => new
        {
            Substation = row.Field<string>("Substation"),
            ColumnTitle = row.Field<string>("ColumnTitle")
        })
        .Select(g => new
        {
            g.Key.Substation,
            g.Key.ColumnTitle,
            MaxRow = g.OrderByDescending(row => decimal.Parse(row.Field<string>("ValueAmount"))).First()
        })
        .Select(x => new 
        {
            ptime = x.MaxRow.Field<string>("ptime"), // voilà
            x.Substation,
            x.ColumnTitle,
            ValueAmount = decimal.Parse(x.MaxRow.Field<string>("ValueAmount"))
        });
