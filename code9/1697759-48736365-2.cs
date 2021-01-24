    var teachersCollection = database.GetCollection<Teacher>("Teachers");
    var regexFilter = Builders<BsonDocument>.Filter.Regex("TopicVideo.VideoLink", "/^http/");
    var httpBsonCount = teachersCollection.Aggregate()
        .Unwind(t => t.TopicVideo)
        .Match(regexFilter)
        .Group(new BsonDocument { { "_id", "null" }, { "count", new BsonDocument { { "$sum", 1 } } } })
        .ToList();
    int httpCount = 0;
    if (httpBsonCount.Any())
        httpCount = httpBsonCount.First()["count"].AsInt32;
