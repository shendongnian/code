    public static class QueryableExtensions
    {
    	public static IQueryable<T> WhereIn<T>(this IQueryable<T> source, IEnumerable<string> searchPhrases, params Expression<Func<T, string>>[] propertySelectors)
    	{
    		var searchTermSets = searchPhrases.Select(x => x.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
    		var c = Expression.Parameter(typeof(T), "c");
    		var searchTerms = Expression.Parameter(typeof(string[]), "searchTerms");
    		var searchTerm = Expression.Parameter(typeof(string), "searchTerm");
    		var allCondition = propertySelectors
    			.Select(propertySelector => (Expression)Expression.Call(
    				propertySelector.Body.ReplaceParameter(propertySelector.Parameters[0], c),
    				"Contains", Type.EmptyTypes, searchTerm))
    			.Aggregate(Expression.OrElse);
    		var allPredicate = Expression.Lambda<Func<string, bool>>(allCondition, searchTerm);
    		var allCall = Expression.Call(
    			typeof(Enumerable), "All", new[] { typeof(string) }, 
    			searchTerms, allPredicate);
    		var anyPredicate = Expression.Lambda<Func<string[], bool>>(allCall, searchTerms);
    		var anyCall = Expression.Call(
    			typeof(Enumerable), "Any", new[] { typeof(string[]) },
    			Expression.Constant(searchTermSets), anyPredicate);
    		var predicate = Expression.Lambda<Func<T, bool>>(anyCall, c);
    		return source.Where(predicate);
    	}
    }
