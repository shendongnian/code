    dbContext.StatusCandidates
        .GroupJoin(
            dbContext.Candidates.Where(u => u.RequestID == requestId)
        ,    x => x.StatusCandidateID
        ,    y => y.StatusID
        ,    (x, y) => new { StatusCandidate = x, StatusGroup = y }
        )
        .SelectMany(
            x => x.StatusGroup.DefaultIfEmpty()
        ,   (x, y) => new { x.StatusCandidate, Status = y}
        )
        .GroupBy(g => new { g.StatusCandidate.Description })
        .Select(z => new AmountStatus{
             StatusName = z.Key.Description
        ,    Amount = z.Count()
        }).ToList();
