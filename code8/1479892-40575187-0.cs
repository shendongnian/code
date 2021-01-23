    public async Task<List<Cylinder>> Get(GetObjects request)
    {
        var collection = Connect._database.GetCollection<Cylinder>();
        var aggregate = collection.Find(_ => true);
        var results = await aggregate.ToListAsync();
        return results;
    }
