    var result = persons
        .GroupBy(p => new { p.FirstName, p.LastName })
        .Select(g => new 
        {
            FirstName = g.Key.FirstName,
            LastName = g.Key.LastName,
            AgeCount = g.Count()
        });
