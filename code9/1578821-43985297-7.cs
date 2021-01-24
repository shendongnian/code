    DataCollection<Entity> entityCollection = _services.RetrieveMultiple(query).Entities;
    
    // Display the results.
    foreach (Contact entity in entityCollection)
    {
        Console.WriteLine("my test: {0}", entity.address1_telephone1);
    }
