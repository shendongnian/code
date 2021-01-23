    public static IEnumerable<TResult> Join<TOuter, TInner, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, IEnumerable<string> propertyNames, Func<TOuter, TInner, TResult> resultSelector)
    {
    	return outer.Join(inner, CreateSelector<TOuter>(propertyNames), CreateSelector<TInner>(propertyNames), resultSelector);
    }
    
    public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TResult>(this IEnumerable<TOuter> outer, IEnumerable<TInner> inner, IEnumerable<string> propertyNames, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
    {
    	return outer.GroupJoin(inner, CreateSelector<TOuter>(propertyNames), CreateSelector<TInner>(propertyNames), resultSelector);
    }
