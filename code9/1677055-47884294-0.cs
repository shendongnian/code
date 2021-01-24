    var q = Table
        .Where(x => x.CustomerId == customerId && x.Isactive)
        .GroupBy(x => new { x.CustomerId, x.ConsentId })
        .SelectMany(g => g
            .GroupBy(x => x.CreatedOn.Date).OrderByDescending(x => x.Key).First()
            .Select(x => new
            {
                g.Key.ConsentId,
                g.Key.CustomerId,
                Date = x.CreatedOn // this is the max-date per group
            }));
