    var collection = _database.GetCollection<Model>("Stuff");
    var filter = Builders<Model>.Filter.Eq("FirstArray.SecondArray.IWantToUpdateThis", OldValue);
    var docIds = collection.Find(filter).Project(x => x.Id).ToList();
    foreach (var docId in docIds)
    {
        var model = collection.Find(e => e.Id == docId).FirstOrDefault();
        foreach (var first in model.FirstArray)
        {
            foreach(var second in first.SecondArray)
            {
                if (second.IWantToUpdateThis == OldValue)
                    second.IWantToUpdateThis = NewValue;
            }
        }
        collection.ReplaceOne(r => r.Id == docId, model);
    }
