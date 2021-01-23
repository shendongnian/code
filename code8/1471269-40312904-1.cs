    /// <summary>
    /// Maps one object into a new object of another type
    /// </summary>
    public static TResult Map<TSource, TResult>(this TSource source)
    	where TSource : class
    	where TResult : class, new()
    {
    	var ret = new TResult();
    	source.Map(ret);
    	return ret;
    }
    
    /// <summary>
    /// Maps one object into an existing object of another type
    /// </summary>
    public static void Map<TSource, TResult>(this TSource source, TResult destination)
    	where TSource : class
    	where TResult : class
    {
    	if (Mapper.FindTypeMapFor<TSource, TResult>() == null)
    		Mapper.CreateMap<TSource, TResult>();
    	Mapper.Map(source, destination);
    }
