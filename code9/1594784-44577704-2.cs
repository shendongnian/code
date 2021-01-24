        MongoClient client = new MongoClient();
        var collection = client.GetDatabase("test").GetCollection<ClassA>("test");
        var b1 = new ClassB() { Status = StatusEnum.One };
        var b2 = new ClassB() { Status = StatusEnum.Two };
        var b3 = new ClassB() { Status = StatusEnum.Three };
        collection.InsertOne(new ClassA { BS = new[] { b3 } });
        collection.InsertOne(new ClassA { BS = new[] { b1, b2 } });
        collection.InsertOne(new ClassA { BS = new[] { b1, b2, b3 } });
        // using LINQ:
        var x = collection.Find(a => !a.BS.Any(bs => bs.Status == StatusEnum.Three)).First();
        //using plain MongoDB query syntax:
        var y = collection.Find("{\"BS.Status\": {$nin: [" + (int)StatusEnum.Three + "]}}").First();
