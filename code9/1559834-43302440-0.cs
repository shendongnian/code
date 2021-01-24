    protected Task<IAsyncCursor<T>> GetEqAsyncCursor<T>(string collectionName,
                IDictionary<string, string> fieldEqValue = null,
                IDictionary<string, string> fieldContainsValue = null,
                IDictionary<string, IEnumerable<string>> fieldEqValues = null,
                IDictionary<string, IEnumerable<string>> fieldElemMatchInValues = null,
                IEnumerable<ObjectId> ids = null)
    {
        var collection = GetCollection<T>(collectionName);
        var builder = Builders<T>.Filter;
    
        IList<FilterDefinition<T>> filters = new List<FilterDefinition<T>>();
    
        if (fieldEqValue != null &&
            fieldEqValue.Any())
        {
            filters.Add(fieldEqValue
                        .Select(p => builder.Eq(p.Key, p.Value))
                        .Aggregate((p1, p2) => p1 | p2));
        }
    
        if (fieldContainsValue != null &&
            fieldContainsValue.Any())
        {
            filters.Add(fieldContainsValue
                        .Select(p => builder.Regex(p.Key, new BsonRegularExpression($".*{p.Value}.*", "i")))
                        .Aggregate((p1, p2) => p1 | p2));
        }
    
        if (fieldEqValues != null &&
            fieldEqValues.Any())
        {
            foreach (var pair in fieldEqValues)
            {
                foreach (var value in pair.Value)
                {
                    filters.Add(builder.Eq(pair.Key, value));
                }
            }
        }
    
        if (fieldElemMatchInValues != null &&
            fieldElemMatchInValues.Any())
        {
            var baseQuery = "{ \"%key%\": { $elemMatch: { $in: [%values%] } } }";
            foreach (var item in fieldElemMatchInValues)
            {
                var replaceKeyQuery = baseQuery.Replace("%key%", item.Key);
                var bsonQuery = replaceKeyQuery.Replace("%values%", 
                            item.Value
                                .Select(p => $"\"{p}\"")
                                .Aggregate((value1, value2) => $"{value1},
     {value2}"));
                var filter = BsonSerializer.Deserialize<BsonDocument>(bsonQuery);
                filters.Add(filter);
            }
        }
    
        if (ids != null &&
            ids.Any())
        {
            filters.Add(ids
                    .Select(p => builder.Eq("_id", p))
                    .Aggregate((p1, p2) => p1 | p2));
        }
    
        var filterConcat = builder.Or(filters);
    
        // Here's how you can debug the generated query
        //var documentSerializer = BsonSerializer.SerializerRegistry.GetSerializer<T>();
        //var renderedFilter = filterConcat.Render(documentSerializer, BsonSerializer.SerializerRegistry).ToString();
    
        return collection.FindAsync(filterConcat);
    }
