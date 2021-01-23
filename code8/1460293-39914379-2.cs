    var result = inventoryDb.Pricing.AsNoTracking()
        .Where(p => p.Quantity > 0m)
        .AsEnumerable()
        .SelectMany(p => Enumerable.Range(0, p.Quantity)
            .Select(i => new
                  {
                     TagNo = p.TagNo,
                     SellingRate = p.SellingRate      
                  }))
        .ToList();
