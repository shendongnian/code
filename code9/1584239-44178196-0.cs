    var collection = db.GetCollection<CollectionObject>(CollectionName);
    collection.Find(
        (FilterDefinition<CollectionObject>)"{ $where : \"this.fileDate > this.splitDate\" }"
    )
    .Project<CollectionObject>(Builders<CollectionObject>.Projection.Include(c => c.Name))
    .ToEnumerable()
    .Select(c => c.Name)
    .Distinct()
    .ToList()
