    DataCollection<Entity> entityCollection = _services.RetrieveMultiple(query).Entities;
    
    // Display the results.
    foreach (Contact contact in entityCollection)
    {
        Console.WriteLine("my test: {0}", contact.test);
    }
