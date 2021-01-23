    var fb = Builders<YourObject>.Filter;
    var idFilter = fb.Eq(f => f.Id, "");//Your filter otherwise you will be updating all documents
    var nullFilter = fb.Eq(f => f.x, BsonNull.Value);//Filter to check x is set to null
            
    var result = await Collection.Find(fb.And(idFilter, nullFilter))
    .CountAsync()
    .ConfigureAwait(false);
    var toAppend = new BsonDocument("y", 42);
    if (result > 0)
    {
        var update = Builders<YourObject>.Update.AddToSet(f => f.x, toAppend);
        await Collection.UpdateOneAsync(f => idFilter, update).ConfigureAwait(false);
    }
    else
    {
        var update = Builders<YourObject>.Update.Set(f => f.x, toAppend);
        await Collection.UpdateOneAsync(x => idFilter, update).ConfigureAwait(false);
    }
