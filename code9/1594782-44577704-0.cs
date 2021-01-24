        MongoClient client = new MongoClient();
        var collection = client.GetDatabase("test").GetCollection<ClassA>("test");
        var b1 = new ClassB() { Status = StatusEnum.One };
        var b2 = new ClassB() { Status = StatusEnum.Two };
        var b3 = new ClassB() { Status = StatusEnum.Three };
        collection.InsertOne(new ClassA { BS = new[] { b3 } });
        collection.InsertOne(new ClassA { BS = new[] { b1, b2 } });
        collection.InsertOne(new ClassA { BS = new[] { b1, b2, b3 } });
        var x = collection.Find("{\"BS.Status\": {$nin: [" + (int)StatusEnum.Three + "]}}").First();
