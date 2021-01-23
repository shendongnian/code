    public void Update(ObjectId id, Product p)
    {
        var res = Builders<Product>.Filter.Eq(pd => pd.ProductId, id);
        var operation = Builders<Product>.Update.Set(u => u.ProductId, id);
        _db.GetCollection<Product>("Product").UpdateOne(res, operation);
    }
