    var duplicates = table.AsEnumerable()
        .GroupBy(r => new { 
            FirstName = r.Field<string>("First Name"),
            LastName  = r.Field<string>("Last Name")
        })
        .Where(g => g.Count() > 1)
        .Select(g => new { Person = g.Key, Count = g.Count(), Rows = g.ToList() });
