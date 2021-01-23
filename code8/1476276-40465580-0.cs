    var session = ... // get a ISession
    // the QueryOver
    var query = session.QueryOver<MyEntity>();
    // apply all filtering, sorting...
    query...
    // GET A ROW COUNT query (ICriteria)
    var rowCount = CriteriaTransformer.TransformToRowCount(query.UnderlyingCriteria);
    // ask for a list, but with a Future, to combine both in one SQL statement
    var list = query
        .Future<MyEntity>()
        .ToList();
    // execute the main and count query at once
    var count = rowCount
        .FutureValue<int>()
        .Value;
    // list is now in memory, ready to be used
    var list = futureList
        .ToList();
