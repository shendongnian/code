    var departments = stops 
        .Where(stop => stop.InitDate != null)
        .SelectMany(stop => new[] { Month = stop.InitDate.Month, Year = stop.InitDate.Year, Duration = stop.Duration })
        .GroupBy(dt => new { dt.Month, dt.Year }) 
        .OrderBy(g => g.Key.Month)
        .ThenBy(g => g.Key.Year) 
        .Select(g => new 
        { 
            Key = g.Key.Month, 
            Año = g.Key.Year, 
            Duration = g.Sum(v => v.Duration), 
            Count = g.Count() 
        });
