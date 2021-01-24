    var dbData = bookings.Where(x => x.DateCreated > from && x.DateCreated < to)
                         .GroupBy(x => x.DateCreated.Date)
                         .ToDictionary(grp => grp.Key, grp => grp.Count());
    var graphData = Enumerable.Range(0, 1 + to.Value.Date.Subtract(from.Date.Value).Days)
        .Select(offset => from.Value.Date.AddDays(offset))
        .Select(day => new GraphData()
        {
            Label = day.ToString("D"),
            Data = dbDate.ContainsKey(day) ? dbData[day] : 0
        }).ToList(); 
