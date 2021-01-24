        public Task Save(string itemId, SubItem subItem)
        {
            var itemFilter = Builders<Item>.Filter.Eq(v => v.Id, itemId);
            var collection = _db.GetCollection<Item>("Items");
    
            var updateBuilder = Builders<Item>.Update.AddToSet(items => items.SubItems, subItem);
    
            collection.UpdateOneAsync(itemFilter, updateBuilder, new UpdateOptions() { IsUpsert = true }).Wait();
        }
