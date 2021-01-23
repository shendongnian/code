    public List<T> FindSearch<T>(string collectionName, string searchWord) {
        IMongoQuery query = Query.Text(searchWord);
        var find = getCollection<T>(collectionName).Find(query).ToList();
        return find;
    }
