    public static List<T> GetEntities<T>(CloudTable table, string filter) where T : ITableEntity, new()
    {
        List<T> entities = new List<T>();
    
        DynamicTableEntity dynamicTableEntity = new DynamicTableEntity();
    
        dynamicTableEntity.Properties = TableEntity.Flatten(new T(), new OperationContext());
    
        TableQuery<DynamicTableEntity> projectionQuery = new TableQuery<DynamicTableEntity>().Where(filter);
        foreach (var dEntity in table.ExecuteQuery(projectionQuery))
        {
            T entity = EntityPropertyConverter.ConvertBack<T>(dEntity.Properties, new OperationContext());
    
            entity.PartitionKey = dEntity.PartitionKey;
            entity.RowKey = dEntity.RowKey;
            entity.ETag = dEntity.ETag;
            entity.Timestamp = dEntity.Timestamp;
    
            entities.Add(entity);
        }
        return entities;
    }
