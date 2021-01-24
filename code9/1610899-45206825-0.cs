    var result = storageCards
        .Where(sc => sc.LocationId == locationId)
        .GroupBy(sc => sc.ProductId)
        .Select(g => new {
            ProductId = g.Key.Value,
            Price = g.OrderByDescending(t => t.Date)
                     .ThenByDescending(t => t.Id)
                     .FirstOrDefault(t => t.Price.HasValue)
                     .LevelInputPrice.Value
        })
        .Where(a => a.Price != null);
