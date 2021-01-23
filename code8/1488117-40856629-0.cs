    var now = DateTime.Now.AddDays(1 - DateTime.Now.Day);
    var months = Enumerable.Range(-11, 12)
        .Select(m => new DateTime(now.AddMonths(m).Year, now.AddMonths(m).Month, 1));
    var ratingsByMonth =
        from month in months
        let key = new { Year = month.Year, Month = month.Month }
        join r in ratings
        on key equals new { r.RatingDate.Year, r.RatingDate.Month }
        into g
        select new {
            Date = key,
            Rating = g.Count() > 0 ? g.Average(x => x.Rating) : 0
        };
