    var baseQuery = _DBContext.BatchRequests
        .Where(x => x.BatchId == null)
        .OrderBy(x => x.CreatedDateTime);
    var result = await baseQuery
    	.Where(x => x.ClientName == baseQuery.Select(y => y.ClientName).FirstOrDefault())
    	.Take(5)
        .ToListAsync();
