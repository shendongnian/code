    planes.SelectMany(p => new[] { 
       new { Airport = origin, IsOrigin = true },
       new { Airport = destination, IsOrigin = false }
    })
      .GroupBy(x => x.Airport)
      .Select(g => new {
         Airport = g.Key,
         AsOriginCount = g.Count(x => x.IsOrigin),
         AsDestinationCount = g.Count(x => !x.IsOrigin)
    })
