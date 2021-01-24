    var contractsQuery = _db.Contracts.AsEnumerable().Where(x => x.Code == query.Code).Select(x=>new {Code=x.Code, Id=x.Id, ...});
    var jobsQuery = _db.Jobs.AsEnumerable().Where(x => x.Code == query.Code).Select(x=>new{Code=x.Code, Id=x.Id, ...});
    // and so on
    var combinedQuery = contractsQuery.UnionAll(jobsQuery).UnionAll(...
    var result = combinedQuery.ToList();
