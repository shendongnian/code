    var weekDays = rad.SMSSentItems
        .Where(x => x.Status == "DELIVRD")
        .GroupBy(x => x.StatusDate.Value.DayOfWeek)
        .Select(g => new { 
            DayOfWeek = g.Key,
            Count = g.Count()
        })
        .ToList();
    
