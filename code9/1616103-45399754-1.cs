    private static string GetTableName(ObjectContext context, Type entityType)
    {
        var entitySet = GetStorageEntitySet(context, entityType);
        return entitySet.Schema + "." + entitySet.Table;
    }
