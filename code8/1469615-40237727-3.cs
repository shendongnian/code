    private void btnSearch_Click(object sender, EventArgs e)
    {
        var client = new MongoClient("mongodb://localhost");
        var database = client.GetDatabase("test");
        var collection = database.GetCollection<MyModel>("users");
        var filter = Builders<MyModel>.Filter.Eq(x => x.SomeProperty == "SomeValue" && x.SomeOtherProperty == "SomeOtherValue");
        var results = collection.Find(filter).ToList();
        //Now you will have a list of MyModel objects in results - List<MyModel>
    }
