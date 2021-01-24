    var LpAb = (
      from portfolio in db.Portfolio
      let bucket = db.Buckets
        .Where(b => l.SicCodeLP == b.SicCode)
        .OrderBy(b => b.Category)
        .FirstOrDefault()
      group portfolio by bucket.Category ?? -1 into g
      select new {
        Category = g.Key,
        TotalVolume = g.Sum(porfolio => porfolio.Volume)
      }).ToList();
