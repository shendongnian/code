    var client = new MongoClient();
    var database = client.GetDatabase("MyDatabase");
    var collection = database.GetCollection<Record>("MyCollection");
    FilterDefinition<Record> filter = Builders<Record>.Filter.Empty;
    if(!string.IsNullOrEmpty(skuValue)) filter &= Builders<Record>.Filter.Eq(r => r.ID, skuValue);
    if(!string.IsNullOrEmpty(purchaseValue)) filter &= Builders<Record>.Filter.Eq(r => r.URL, purchaseValue);
    if(!string.IsNullOrEmpty(sliderValue)) filter &= Builders<Record>.Filter.Eq(r => r.Refer, sliderValue);
    if(!string.IsNullOrEmpty(categoryValue)) filter &= Builders<Record>.Filter.Eq(r => r.Category, categoryValue);
