            var mongoClient = new MongoClient();
            var collection = mongoClient.GetDatabase("test").GetCollection<Rootobject>("test");
            ObjectId someId = new ObjectId("599e670f2720317af451db9e");
            string someName = "Car 1";
            var item = await collection.AsQueryable()
                .Where(x => x.Id == someId)
                .SelectMany(x => x.Cars)
                .Where(x => x.Name == someName)
                .FirstOrDefaultAsync();
