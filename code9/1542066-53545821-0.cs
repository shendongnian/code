    List<BsonDocument> batch = new List<BsonDocument>();
    var collection = _LocalDB.GetCollection<HashEntry>("Files");
    
    foreach (var item in HashList)
    {    
        var filter = Builders<HashEntry>.Filter.Eq("Hash", item);
        var result = collection.Find(filter).ToList();
    
        if (result.Count==0)
        {
            var newHash = new HashEntry();
            newHash.FileList = new List<FileMetadata>();
    
            newHash.Hash = item;
            newHash.FileList.Add(inputFile);
            batch.Add(newHash.ToBson());
        }
        else
        {
            var update = Builders<HashEntry>.Update.Push("FileList",inputFile);
            collection.FindOneAndUpdate(filter,update);
        }
    }
    collection.InsertBatch(batch.ToArray());
