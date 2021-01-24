    var LpAb = (
      from portfolio in db.Portfolio
      let category = db.Buckets
        .Where(b => l.SicCodeLP == b.SicCode)
        .FirstOrDefault()?.Category ?? -1
      group portfolio by category into g
      select new {
        Category = g.Key,
        TotalVolume = g.Sum(porfolio => porfolio.Volume)
      }).ToList();
