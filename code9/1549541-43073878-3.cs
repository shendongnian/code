    var queryBase = _session.QueryOver<A>()
        .JoinQueryOver(a => a.Bs)
        .Where(b => b.Id == idB);
    var queries = new List<IEnumerable<A>>();
    foreach (Expression<Func<A>, object>> field in eagerFields)
        queries.Add(queryBase
            .Fetch(field).Eager
            .Future());
    return queries.Count == 0 ? queryBase.List().First() : queries[0].First();
