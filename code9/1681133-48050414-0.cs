    public static IEnumerable<Product> GetFromIDs(List<string> productIDs)
    {
        var client = new MongoClient(new MongoUrl("mongodb://localhost:27017"));
    
        var db = client.GetDatabase("Database");
    
        var filter = Builders<Product>.Filter
            .In(p => p.Id, productIDs);
    
        var products = db.GetCollection<Product>("Products")
            .Find(filter)
            .ToEnumerable();
    
        return products;
    }
