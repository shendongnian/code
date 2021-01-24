    var dbData = bookings.Where(x => x.DateCreated > from && x.DateCreated < to)
                         .GroupBy(x => x.DateCreated.Date)
                         .Select(grp => new { grp.Key, grp.Count() })
                         .ToDictionary(x => x.Key, x => x.Count);
    var graphData = Enumerable.Range(0, 1 + to.Value.Date.Subtract(from.Date.Value).Days)
        .Select(offset => from.Value.Date.AddDays(offset))
        .Select(day => new GraphData()
        {
            Label = day.ToString("D"),
            Data = dbDate.TryGetValue(day, out var count) ? count : 0
        }).ToList(); 
