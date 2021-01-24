	public virtual IList<T> FindBy<T>(ProjectionList columnList, Junction where, int top) where T : BaseEntity
	{
		IList<T> instance = GetQueryOver<T>(columnList, where).Take(top).List();
		return instance;
	}
	public virtual IQueryOver<T> GetQueryOver<T>(ProjectionList columnList, Junction where) where T : BaseEntity
	{
		IQueryOver<T> query = null;
		if((columnList != null) && (where != null))
		{
			query = nhSession.QueryOver<T>()
					.Select(columnList)
					.TransformUsing(Transformers.AliasToBean<T>())
					.Where(where);
		}
		else if((columnList != null) && (where == null))
		{
			query = nhSession.QueryOver<T>()
					.Select(columnList)
					.TransformUsing(Transformers.AliasToBean<T>());
		}
		else if((columnList == null) && (where != null))
		{
			query = nhSession.QueryOver<T>()
					.Where(where);
		}
		else
		{
			query = nhSession.QueryOver<T>();
		}
		return query;
	}
