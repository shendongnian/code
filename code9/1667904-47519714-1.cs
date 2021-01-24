    var collection = new MongoClient().GetDatabase("test").GetCollection<Book>("test");
    var pipeline = collection.Aggregate()
        .Match(b => b.Name == "My First Book")
        .Project("{Tags: { $objectToArray: \"$Tags\" }}")
        .Unwind("Tags")
        .SortByCount<BsonDocument>("$Tags");
    var output = pipeline.ToList().ToJson(new JsonWriterSettings {Indent = true});
    Console.WriteLine(output);
