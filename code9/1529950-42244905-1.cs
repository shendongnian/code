    struct KeyPropertyInfo
    {
    	public string Name;
    	public Type ClrType;
    }
    public static IReadOnlyList<KeyPropertyInfo> GetPrimaryKeyProperties(DbContext dbContext, Type clrEntityType)
    {
    	var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
    	var metadata = objectContext.MetadataWorkspace;
    	var objectItemCollection = ((ObjectItemCollection)metadata.GetItemCollection(DataSpace.OSpace));
    	var entityType = metadata.GetItems<EntityType>(DataSpace.OSpace)
    		.Single(e => objectItemCollection.GetClrType(e) == clrEntityType);
    	return entityType.KeyProperties
    		.Select(p => new KeyPropertyInfo
    		{
    			Name = p.Name,
    			ClrType = p.PrimitiveType.ClrEquivalentType
    		})
    		.ToList();
    }
