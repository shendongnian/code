    var Data=cacheService.GetOrSet("CACHEKEY", Db.BusinessLine.AsQueryable()
                .Where(x => x.Label.Contains(query))
                .Take(10)
                .Select(x => new { id = x.BusinessLineId, text = x.Label })
                .ToList());
