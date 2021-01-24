    // Coordinate is a class
    public async Task<List<Coordinate>> Get(double longitude)
    {         
        var filter = new BsonDocument("longitude", longitude);
        var list = await Collection.Find(filter).ToListAsync();
        return list;
    }
