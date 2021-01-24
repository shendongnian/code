    var baseQuery = _DBContext.BatchRequests
        .Where(x => x.BatchId == null)
        .OrderBy(x => x.CreatedDateTime);
    var clientName = await baseQuery
        .Select(x => x.ClientName)
        .FirstOrDefaultAsync();
    var result = await baseQuery
        .Where(x => x.ClientName == clientName)
        .Take(5)
        .ToListAsync();
