    public T CreateAndPopulate<T>(IEnumerable<KeyValueStore> propStore) where T:class,new()
    {
    	var propsDic = propStore.ToDictionary(x => x.Key, x => x.Value);
    	T item = new T();
    	var type = typeof(T);
    	var props = type.GetProperties();
    	foreach(var prop in props)
    	{
    		prop.SetMethod.Invoke(item, new object[]{ propsDic[prop.Name] });
    	}
    	return item;
    }
