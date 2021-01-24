    List<int> personIds = GetPersonIds(clientAddress, clientUsername, clientPassword);
    var customResults = new List<CustomApiResult>();
    Parallel.ForEach(personIds.Batch(100), 
    new ParallelOptions()
    {
        MaxDegreeOfParallelism=5
    },
    (personIdsBatch) =>
    {
        var results = GetCustomResultsByBatch(address, username, password, personIdsBatch);
        lock (customResults)
        {
            customResults.AddRange(results);
        }
    });
