    // This selection is performed in the database
    var raw = DbContext.Orders
        .Where(i => i.Id== Id)
        .GroupBy(row => new { row.Status })
        .Select(g => new Stats {
            Status = g.Key.Status,
            Count = g.Count()
        }).ToList();
    // This join is performed in memory
    var results =
        from e in Enum.GetValues(typeof(Status)).Cast<Status>()
        join r in raw on e equals r.Status into rs
        from r in rs.DefaultIfEmpty()
        select new { Status = e, Count = r?.Count ?? 0};
