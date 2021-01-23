     public List<T> FindSearch<T>(string collectionName, string fieldName)
            {
                IMongoQuery query = Query.Text(fieldName);
                var find = getCollection<T>(collectionName).Find(query).ToList();
                return find;
            }
