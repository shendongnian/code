    public Type GetItemType(IEnumerable<object> collection)
    {
        Type collectionType = collection.GetType();
    	collectionType.Dump();
	
    	return collectionType.GetInterfaces()
    		.Where( iface => iface.IsGenericType )
    		.Where( iface => iface.GetGenericTypeDefinition() == typeof( IEnumerable<> ) )
    		.Select( iface => iface.GetGenericArguments()[0] ).FirstOrDefault();
    }
