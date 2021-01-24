    public IEnumerable<Product> GetFromIDs(List<string> productIDs)
    {
        var client = new MongoClient(new MongoUrl("mongodb://localhost:27017"));
        var db = client.GetDatabase("Database");
        var productsCollection = db.GetCollection<Product>("Products");
        
        var productObjectIDs = productIDs.Select(id => new ObjectId(id));
    
        var filter = Builders<Product>.Filter
            .In(p => p.Id, productObjectIDs);
        var products = productsCollection
            .Find(filter)
            .ToEnumerable();
    
        return products;
    }
