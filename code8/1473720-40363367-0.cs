    var keywords = items.GroupBy(v2 => v2.Key, StringComparer.InvariantCultureIgnoreCase)
                      .Select(g => new CustomDTO
                      {
                          Key = g.Key,
                          Count = g.Count(),
                          Sales = g.Sum(k => k.Sale)
                      })
                      .OrderByDescending(e => e.Count).Distinct()
                      .ToList(); 
