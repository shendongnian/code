    var now = DateTime.Now.AddDays(1 - DateTime.Now.Day);
    var months = Enumerable.Range(-11, 12)
        .Select(m => new DateTime(now.AddMonths(m).Year, now.AddMonths(m).Month, 1));
    var ratingsByMonth =
        from date in months
        let month = new { Year = date.Year, Month = date.Month }
        join r in ratings
        on month equals new { r.RatingDate.Year, r.RatingDate.Month }
        into g
        select new {
            Date = month,
            Rating = g.Count() > 0 ? g.Average(x => x.Rating) : 0
        };
