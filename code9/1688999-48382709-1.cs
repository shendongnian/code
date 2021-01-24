    public static IQueryable<TRet> GroupByProperty<TModel, TRet>(IQueryable<TModel> q, PropertyInfo p)
    {
        ParameterExpression pe = Expression.Parameter(typeof(TModel));
        Expression se = Expression.Convert(Expression.Property(pe, p), typeof(TRet));
        return q.GroupBy(Expression.Lambda<Func<TModel, TRet>>(se, pe)).Select(x => x.Key);
    }
