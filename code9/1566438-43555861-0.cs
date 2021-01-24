    public static IQueryOver<tRoot, tSubType> AddDateRangeCritery<tRoot, tSubType>(
        this IQueryOver<tRoot, tSubType> query,
        System.Linq.Expressions.Expression<Func<tSubType, DateTime>> expr,
        DatesRange range)
    {
        if (range?.minDate != null)
        {
            var propr = expr.Body;
            var value = Expression.Constant(range.minDate.Value);
            var cmp = Expression.GreaterThanOrEqual(propr, value);
            var expr2 = Expression.Lambda<Func<tSubType, bool>>(cmp, expr.Parameters);
            query.Where(expr2);
        }
        return query;
    }
