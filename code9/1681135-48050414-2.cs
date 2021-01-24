    public static IEnumerable<Product> GetFromIDs(List<string> productIDs)
    {
        var client = new MongoClient(new MongoUrl("mongodb://localhost:27017"));
        var db = client.GetDatabase("Database");
        var productsCollection = db.GetCollection<Product>("Products");
            
        var filter = Builders<Product>.Filter
            .In(p => p.Id, productIDs);
        var products = productsCollection
            .Find(filter)
            .ToEnumerable();
    
        return products;
    }
