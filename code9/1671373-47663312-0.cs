    var collection = new MongoClient().GetDatabase("test").GetCollection<Level>("test");
    var projection = Builders<Level>.Projection.ElemMatch(level => level.ConnectingQuestions, q => q.QuestionNumber == 2);
    var bsonDocument = collection
        // filter out anything that we're not interested in
        .Find(level => level.Id == "59e850f95322e01e88f131c1")
        .Project(projection)
        .First();
    // get first (single!) item from "ConnectingQuestions" array
    bsonDocument = bsonDocument.GetElement("ConnectingQuestions").Value.AsBsonArray[0].AsBsonDocument;
    // deserialize bsonDocument into ConnectingQuestions instance
    ConnectingQuestion cq = BsonSerializer.Deserialize<ConnectingQuestion>(bsonDocument);
