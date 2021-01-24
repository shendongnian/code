    var historicalPrices = await _context.ProductHistoricalPrices.Where(x => x.ModifiedAt >= startDate && x.ModifiedAt <= endDate).Select(x => new
        {
         ProductId = x.ProductId,
         ProductName = x.Product.Name,
         Price = x.NewPrice,
         ModificationDate = x.ModifiedAt
        }).GroupBy(x => x.ProductId).Select(x => new
    {
      ProductName = x.FirstOrDefault().ProductName,
      InitialPrice = x.OrderBy(x => x.ModificationDate).FirstOrDefault().Price,
      FinalPrice = x.OrderByDescending(x => x.ModificationDate).FirstOrDefault().Price
    }).ToListAsync();
 
 
