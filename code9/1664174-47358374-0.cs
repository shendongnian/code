	[EnableQuery]
	public IQueryable<SomePOCO> GetBuiltInTypes()
	{
		var dbQuery = from obj in FncCall() select obj;
		// at this point the database has not yet been called
		IQueryable<SomePOCO> result = DoSomeWork(dbQuery);
		return result;
	}
	private IQueryable<SomePOCO> DoSomeWork(IQueryable<SomePOCO> dbQuery)
	{
	   // still not executed against db
	   return dbQuery.Where(x => x.something == "something");
	}
