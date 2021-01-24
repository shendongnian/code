     public async Task<List<Item>> GetItemsFromQueue(string queueId)
     { 
    	return await Collection.Find(queue => queue.Id == queueId)
            .Project(new ProjectionDefinitionBuilder<Queue>().Expression(q => q.Items))
            .FirstOrDefaultAsync();
    }
