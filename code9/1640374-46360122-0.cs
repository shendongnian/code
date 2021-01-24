	public object Resolve<T, TQuery>(TQuery query)
		where T : IQueryHandler<TQuery, object>, new()
		where TQuery : class, IQuery
	{
		return new T().Execute(query);
	}
