    var result = storageCards
        .Where(sc => sc.LocationId == locationId)
        .GroupBy(sc => sc.ProductId)
        .Select(g => new {
            ProductId = g.Key.Value,
            Price = g.OrderByDescending(t => t.Date)
                     .ThenByDescending(t => t.Id)
                     .Where(t => t.Price.HasValue)
                     .Select(t => t.LevelInputPrice.Value)
                     .FirstOrDefault()
        })
        .Where(a => a.Price != null);
