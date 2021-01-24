    var historicalStartPrices = await _context.ProductHistoricalPrices;
    // only get prices that come between start and end dates
    .Where(p => p.ModifiedAt >= start && p.ModifiedAt <= end
    // order from most recent -> oldest by modified date
    .OrderByDescending(p => p.ModifiedAt)
    // take only prices foreach products in ProductHistoricalPrices
    .Select(g => g.NewPrice)
    // enumerate the results
    .ToListAsync();
