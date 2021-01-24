    // Get the empty definition for the EntriesCollection
    var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
    
    // Populate the definition with your IMemoryCache instance.  
    // It needs to be cast as a dynamic, otherwise you can't
    // loop through it due to it being a collection of objects.
    var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(instanceIMemoryCache) as dynamic;
    
    // Define a new list we'll be adding the cache entries too
    List<Microsoft.Extensions.Caching.Memory.ICacheEntry> cacheCollectionValues = new List<Microsoft.Extensions.Caching.Memory.ICacheEntry>();
    
    foreach (var cacheItem in cacheEntriesCollection)
    {
    	// Get the "Value" from the key/value pair which contains the cache entry	
    	Microsoft.Extensions.Caching.Memory.ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
    	
    	// Add the cache entry to the list
    	cacheCollectionValues.Add(cacheItemValue);
    }
    
    // You can now loop through the cacheCollectionValues list created above however you like.
