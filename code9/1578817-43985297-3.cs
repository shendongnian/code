    DataCollection<Entity> entityCollection = _services.RetrieveMultiple(query).Entities;
    
    // Display the results.
    foreach (ABC entity in entityCollection)
    {
        Console.WriteLine("my test: {0}", entity.test);
    }
