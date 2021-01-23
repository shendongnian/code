    var publicationQuery = new List<Publication>().AsQueryable(); // From a DbSet...
    var query = publicationQuery
        .Select(x => new
        {
            PublicationId = x.Id,
            LogCount = x.ViewLogs.Count
        })
        .OrderByDescending(x => x.LogCount);
