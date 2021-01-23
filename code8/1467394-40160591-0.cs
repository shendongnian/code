    foreach (string colName in collections)
    {
        var collection = database.GetCollection(colName);
        //Query for all docents that have pID
        IMongoQuery query = Query.Exists("pID");
        //Query for all docents that have Subdocument.pID
        IMongoQuery subQuery = Query.Exists("SubDocument.pID");
        IMongoQuery totalQuery = Query.Or([query, subQuery]);
        pDocs.AddRange(collection.Find(totalQuery));
    }
