    public IEnumerable<TEntity> List(params Expression<Func<TEntity, object>>[] eagerFields)
		{
			var query = _session.QueryOver<TEntity>();
			query = AddReferenceFetch(query, eagerFields);
			return query.TransformUsing(Transformers.DistinctRootEntity).List();
		}
    private IQueryOver<TEntity, TEntity> AddReferenceFetch(IQueryOver<TEntity, TEntity> query, params Expression<Func<TEntity, object>>[] eagerFields)
    		{
    			foreach (Expression<Func<TEntity, object>> field in eagerFields)
    				query = query.Fetch(field).Eager;
    
    			return query;
    		}
