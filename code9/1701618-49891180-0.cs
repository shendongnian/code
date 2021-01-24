    HashSet<string> fields = new HashSet<string>();
    BsonDocument query = BsonDocument.Parse(filter);
    var result = database.GetCollection<BsonDocument>(collection).Find(new BsonDocument());
    
    // Populate fields with all unique fields, see below for examples how.
    var csv = new StringBuilder();
    string headerLine = string.Join(",", fields);
    csv.AppendLine(headerLine);
    foreach (var element in result.ToListAsync().Result)
    {
        string line = null;
        foreach (var field in fields)
        {
            BsonValue value;
            if (field.Contains("."))
            {
                value = GetNestedField(element, field);
            }
            else
            {
                value = element.GetElement(field).Value;
            }
            // Example deserialize to string
            switch (value.BsonType)
            {
                case BsonType.ObjectId:
                    line = line + value.ToString();
                    break;
                case BsonType.String:
                    line = line + value.ToString();
                    break;
                case BsonType.Int32:
                    line = line + value.AsInt32.ToString();
                    break;
            }
            line = line + ",";
        }
        csv.AppendLine(line);
    }
    File.WriteAllText("D:\\temp.csv", csv.ToString());
