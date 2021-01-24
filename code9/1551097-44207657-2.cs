    [QueryInterceptor("Items")]
    public Expression<Func<Item, bool>> InterceptItemRead()
    {
    	return DefaultFilter<Item>();
    }
