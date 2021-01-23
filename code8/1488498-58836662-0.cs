    var dbset = typeof(T).Name;
    var tables = MongoDb.ListCollectionNames().ToList();
    if (!tables.Any(x => x == dbset))
    {
        MongoDb.CreateCollection(dbset);
    }
    return MongoDb.GetCollection<T>(dbset);
