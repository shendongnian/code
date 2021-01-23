    foreach (string colName in collections)
    {
        var collection = database.GetCollection(colName);
        
        //Query for all documents that have pID
        IMongoQuery query = Query.And([Query.Exists("pID"), // The field exists
          Query.NE("pID", BsonNull.Value), //It is not "null"
          Query.NE("pID", BsonString.Null)]); //It is not empty i.e. = ""
        //Query for all documents that have Subdocument.pID
        IMongoQuery subQuery = Query.And([Query.Exists("SubDocument.pID"), // The field exists
          Query.NE("SubDocument.pID", BsonNull.Value), //It is not "null"
          Query.NE("SubDocument.pID", BsonString.Null)]); //It is not empty i.e. = ""
        IMongoQuery totalQuery = Query.Or([query, subQuery]);
        pDocs.AddRange(collection.Find(totalQuery));
    }
