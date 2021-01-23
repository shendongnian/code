    static Expression<Func<MyTable, IEnumerable<MyTable>>> ParentsSelector(int maxLevels)
    {
    	var parameter = Expression.Parameter(typeof(MyTable), "x");
    	var parents = new Expression[maxLevels];
    	for (int i = 0; i < parents.Length; i++)
    		parents[i] = Expression.Property(i > 0 ? parents[i - 1] : parameter, "Parent");
    	Expression<Func<MyTable, bool>> predicate = x => x != null;
    	var result = Expression.Call(
    		typeof(Enumerable), "Where", new[] { parameter.Type },
    		Expression.NewArrayInit(parameter.Type, parents), predicate);
    	return Expression.Lambda<Func<MyTable, IEnumerable<MyTable>>>(result, parameter);
    }
