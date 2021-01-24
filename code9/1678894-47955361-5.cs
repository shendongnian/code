    var weekDays = rad.SMSSentItems
        .Where(x => x.Status == "DELIVRD")
        .AsEnumerable()
        .GroupBy(x => x.StatusDate.Value.DayOfWeek)
        .Select(g => {
            //Total items sent on this day of the week
            var totalItemCount = g.Count();
            //Total number if this distinct day of the week
            var totalNumberOfDays = g.Select(x => x.StatusDate.Value.Date).Distinct().Count();
            return new {
                DayOfWeek = g.Key,
                TotalItemCount = totalItemCount,
                TotalNumberOfDays = totalNumberOfDays,
                AverageItemPerDay = totalItemCount / totalNumberOfDays
            };
        })
        .ToList();
    
