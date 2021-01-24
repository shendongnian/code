    public static IQueryable<IGrouping<TRet, TModel>> GroupByProperty<TModel, TRet>(IQueryable<TModel> q, PropertyInfo p)
    {
        ParameterExpression pe = Expression.Parameter(typeof(TModel));
        Expression se = Expression.Convert(Expression.Property(pe, p), typeof(TRet));
        return q.GroupBy(Expression.Lambda<Func<TModel, TRet>>(se, pe));
    }
    public static IQueryable<IGrouping<dynamic, TModel>> GroupByDynamic<TModel>(this IQueryable<TModel> q, string name)
    {
        Type entityType = typeof(TModel);
        PropertyInfo p = entityType.GetProperty(name);
        MethodInfo m = typeof(B).GetMethod("GroupByProperty").MakeGenericMethod(entityType, p.PropertyType);
        return (IQueryable<IGrouping<dynamic, TModel>>)m.Invoke(null, new object[] { q, p });
    }
