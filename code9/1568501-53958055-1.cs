    var parameters = noSplit.Select(x => new { NO = x, SOME_FLAG = flag }).ToList();
    
    var queryResult = dbConnection.Execute(insertSelectQuery, parameters, transactionIfExists);
    
    if (queryResult != parameters.Count)
    {
        throw new Exception("Can not find some no");
    }
