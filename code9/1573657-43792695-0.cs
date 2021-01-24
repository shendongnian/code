    var entityCollection = new EntityCollection();
    
    Console.WriteLine(entityCollection.Entities.Count()); // 0
    
    entityCollection.Entities.Add(new Entity());
    
    Console.WriteLine(entityCollection.Entities.Count()); // 1
