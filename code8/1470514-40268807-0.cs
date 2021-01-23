    public static class Expressions
    {
    	public static Expression<Func<TSource, int>> DictionaryOrder<TSource, TKey, TOrder>(Expression<Func<TSource, TKey>> source, IReadOnlyDictionary<TKey, TOrder> by)
    	{
    		var body = by
    			.OrderBy(entry => entry.Value)
    			.Select((entry, ordinal) => new { entry.Key, ordinal })
    			.Reverse()
    			.Aggregate((Expression)null, (next, item) => next == null ? (Expression)
    				Expression.Constant(item.ordinal) :
    				Expression.Condition(
    					Expression.Equal(source.Body, Expression.Constant(item.Key)),
    					Expression.Constant(item.ordinal),
    					next));
    
    		return Expression.Lambda<Func<TSource, int>>(body, source.Parameters[0]);
    	}
    }
