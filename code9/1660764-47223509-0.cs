    public bool Update(BsonValue id, T document)
    {
        if (document == null) throw new ArgumentNullException("document");
        if (id == null || id.IsNull) throw new ArgumentNullException("id");
        // get BsonDocument from object
        var doc = _mapper.ToDocument(document);
        // set document _id using id parameter
        doc["_id"] = id;
        return _engine.Value.Update(_name, new BsonDocument[] { doc }) > 0;
    }
