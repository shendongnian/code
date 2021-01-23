        var collection = _database.GetCollection<BsonDocument>("restaurants");
        var reader = new StreamReader("C:\\primer-dataset.json");
        string line;
        var sb = new StringBuilder();
        while ((line = reader.ReadLine()) != null)
        {
           sb.Append(line);
        }
        var arr = JArray.Parse(sb.ToString());
        foreach(JObject o in arr)
        {
           var d = BsonDocument.Parse(o.ToString());
           collection.InsertOne(d);
        }     
