    var caf = new BsonDocumentArrayFilterDefinition<ModelItem>(new MongoDB.Bson.BsonDocument("caf.ItemId", new MongoDB.Bson.BsonDocument("$eq", YYYY)));
    var oaf = new BsonDocumentArrayFilterDefinition<ModelItem>(new MongoDB.Bson.BsonDocument("oaf.ItemId", new MongoDB.Bson.BsonDocument("$ne", YYYY)));
    var query = Builders<Model>.Filter.Eq(_ => _.Id, XXXX);
    var update = Builders<Model>.Update.Combine(
        Builders<Model>.Update.Inc("Items.$[caf].Amount", incrementValue),
        Builders<Model>.Update.Inc("Items.$[oaf].Amount", -incrementValue)
    );
    await this.Collection.UpdateManyAsync(query, update, new UpdateOptions()
    {
        ArrayFilters = new List<ArrayFilterDefinition>() { caf, oaf}
    });
