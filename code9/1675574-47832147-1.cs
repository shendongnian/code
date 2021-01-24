    var myUpdates = new List<MyUpdate>()
    {
        new MyUpdate(){ Filter = builder.Eq(x => x.Id, ObjectId.Parse("5a33b9bdec34269d4c03c939")),
            Update = Builders<MyOrder>.Update.Set(x=> x.Order, "First Order") },
        new MyUpdate(){ Filter = builder.Eq(x => x.Id,ObjectId.Parse("5a33b9ceec34269d4c03c941")),
            Update = Builders<MyOrder>.Update.Set(x=> x.Order, "Second Order") },
        new MyUpdate(){ Filter = builder.Eq(x => x.Id, ObjectId.Parse("5a33b9daec34269d4c03c944")),
            Update = Builders<MyOrder>.Update.Set(x=> x.Order, "Third Order") }
    }
