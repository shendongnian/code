    // Get your query set up, but don't execute anything on it yet.
    var results = _dbContext.Logs.Select(l => new LogEntity
                                        {
                                            LogId = l.LogId,
                                            l.Message
                                        })
                                 .OrderBy(l => l.DateTime);
    var pageList = new PageList<LogEntity>();
    await pageList.Create(results, pageNumber, pageSize);
    return pageList;
