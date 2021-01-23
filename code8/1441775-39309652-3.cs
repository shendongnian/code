    public static class QueryableExtensions
    {
    	public static IQueryable<T> WhereIn<T>(this IQueryable<T> source, IEnumerable<string> searchPhrases, params Expression<Func<T, string>>[] propertySelectors)
    	{
    		var searchTermSets = searchPhrases.Select(x => x.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
    		var c = Expression.Parameter(typeof(T), "c");
    		var body = searchTermSets
    			.Select(searchTerms => searchTerms
    				.Select(searchTerm => propertySelectors
    					.Select(propertySelector => (Expression)Expression.Call(
    						propertySelector.Body.ReplaceParameter(propertySelector.Parameters[0], c),
    						"Contains", Type.EmptyTypes, Expression.Constant(searchTerm)))
    					.Aggregate(Expression.OrElse))
    				.Aggregate(Expression.AndAlso))
    			.Aggregate(Expression.OrElse);
    		var predicate = Expression.Lambda<Func<T, bool>>(body, c);
    		return source.Where(predicate);
    	}
    }
