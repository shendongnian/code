    var longRunningQueries = context.TblMessageQueues
        .GroupBy(x => x.SequencingQueue)
        .Select(g => new {
            DateDiff = DbFunctions.DiffMonths(g.Min(x => x.QueuedTime), g.Max(x => x.QueuedTime)),
            SequencingQueue = g.Key
        }).OrderByDescending(a => a.DateDiff)
        .Select(t => new TblMessageQueueDto {
            DateDiff = t.DateDiff,
            SequencingQueue = t.SequencingQueue
        }).ToList();
