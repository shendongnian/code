    public static void ProcessInBatches<TItem>(this IEnumerble<TItem> items, int batchSize, Action<IEnumerable<TItem>> processBatch) {
    
    	//Batch the data
    	var batches = items
          .Select((item, index) => new { item, index })
          .GroupBy(_ => _.index / batchSize, _ => _.item);
    
        //Process the batches.
        foreach (var batch in batches) {
            //Each batch would be IEnumerable<TItem>
    		processBatch(batch);
    	}
    }
