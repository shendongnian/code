    static void BatchInsertOrReplace<T>(List<T> items, CloudTable table) where T : ITableEntity
    {
        List<ITableEntity> batch = new List<ITableEntity>();
        TableBatchOperation batchOperation = new TableBatchOperation();
        foreach (var item in items)
        {
            batch.Add(item);
            batchOperation.InsertOrReplace(item);
    
            if (batch.Count == 100)
            {
                table.ExecuteBatch(batchOperation);
                batchOperation.Clear();
                batch.Clear();
            }
        }
    
        // Process last batch
        if (batch.Any())
        {
            table.ExecuteBatch(batchOperation);
        }
    }
