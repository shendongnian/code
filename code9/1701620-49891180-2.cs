    HashSet<string> fields = new HashSet<string>();
    var result = database.GetCollection<BsonDocument>(collection).Find(new BsonDocument());
    var result = database.GetCollection<BsonDocument>(collection).Find(new BsonDocument());
    foreach (var element in result.ToListAsync().Result)
    {
        ProcessTree(fields, element, "");
    }
    private void ProcessTree(HashSet<string> fields, BsonDocument tree, string parentField)
    {
        foreach (var field in tree)
        {
            string fieldName = field.Name;
            if (parentField != "")
            {
                    fieldName = parentField + "." + fieldName;
            }
            if (field.Value.IsBsonDocument)
            {
                ProcessTree(fields, field.Value.ToBsonDocument(), fieldName);
            }
            else
            {
                fields.Add(fieldName);
            }
        }
