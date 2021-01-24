	protected IQueryable<dynamic> TestMethod(string r)
	{
		return JsonExtensions.ReadJsonAsDynamicQueryable(r);
	}
	
