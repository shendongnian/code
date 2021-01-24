    static Action<object, object> CreateAddToCollectionAction(Type itemType)
    {
    	var item = Expression.Parameter(typeof(object), "item");
    	var collection = Expression.Parameter(typeof(object), "collection");
    	var body = Expression.Call(
    		Expression.Convert(collection, typeof(ICollection<>).MakeGenericType(itemType)),
    		"Add",
    		Type.EmptyTypes,
    		Expression.Convert(item, itemType)
    	);
    	var lambda = Expression.Lambda<Action<object, object>>(body, item, collection);
    	return lambda.Compile();
    }
