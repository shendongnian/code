    public static InsertStatus Add<T>(T ent, Expression<Func<T,P>> keySelector) where P : class
    {
        System.Data.Linq.Table<T> t = otdc.GetTable<T>();
        var memberAccess = (keySelector as LambdaExpression)?.Body as MemberExpression;
        ParameterExpression paramExpr = Expression.Parameter(typeof(T), "e");
        Expression<Func<T, bool>> predicate = Expression.Lambda<Func<T,bool>>(
                Expression.Equal(memberAccess.Update(Expression.Constant(ent)), memberAccess.Update(paramExpr)), paramExpr);
        if (t.Any(predicate))
        {
