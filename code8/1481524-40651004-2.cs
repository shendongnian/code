    static readonly Dictionary<Tuple<Type, string>, Func<object, object>> selectorCache = new Dictionary<Tuple<Type, string>, Func<object, object>>();
    
    public static Func<object, object> GetSelector(Type type, string memberPath)
    {
    	var key = Tuple.Create(type, memberPath);
    	Func<object, object> value;
    	lock (selectorCache)
    	{
    		if (!selectorCache.TryGetValue(key, out value))
    			selectorCache.Add(key, value = CreateSelector(type, memberPath));
    	}
    	return value;
    }
