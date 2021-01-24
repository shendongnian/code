    var start = new DateTime(2017, 03, 31);
    var end = new DateTime(2017, 03, 31);
    var project1 = new BsonDocument
        {
            { "CreatedOn", 1 },
            { "Description", 1 },
            { "CreatedOnDate", new BsonDocument("$dateToString", new BsonDocument("format", "%Y-%m-%d")
                                .Add("date", new BsonDocument("$add", new BsonArray(new object[] { "$CreatedOn", 5 * 60 * 60 * 1000 }))))
            }
        };
    var match = new BsonDocument("CreatedOnDate", new BsonDocument("$gte", start.ToString("yyyy-MM-dd")).Add("$lte", end.ToString("yyyy-MM-dd")));
    var project2 = new BsonDocument
        {
            { "CreatedOn", 1 },
            { "Description", 1 }
        };
    var pipeline = collection.Aggregate()
    .Project(project1)
    .Match(match)
    .Project(project2);
    var list = pipeline.ToList();
    List<Student> searchResult = list.Select(doc => BsonSerializer.Deserialize<Student>(doc)).ToList();
