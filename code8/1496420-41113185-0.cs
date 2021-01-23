    var publicationQuery = new List<Publication>().AsQueryable();
    var viewLogQuery = new List<ViewLog>().AsQueryable();
    var leftJoinQuery = publicationQuery
        .GroupJoin(viewLogQuery, x => x.Id, x => x.PublicationId, (pub, logs) => new
        {
            PublicationId = pub.Id,
            LogCount = logs.Count()
        })
        .OrderByDescending(x => x.LogCount);
