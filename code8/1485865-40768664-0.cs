    private static IQueryable<T> _whereDate<T>(this IQueryable<T> data, MemberExpression date1Expression, ParameterExpression parameter, DateTime date)
    {
        var date1Year = Expression.Property(date1Expression, "Year");
        var date1Month = Expression.Property(date1Expression, "Month");
        var date1Day = Expression.Property(date1Expression, "Day");
        var date2Year = Expression.Constant(date.Year);
        var date2Month = Expression.Constant(date.Month);
        var date2Day = Expression.Constant(date.Day);
        var yearsEqual = Expression.Equal(date1Year, date2Year);
        var monthsEqual = Expression.Equal(date1Month, date2Month);
        var daysEqual = Expression.Equal(date1Day, date2Day);
        var allPartsEqual = Expression.AndAlso(Expression.AndAlso(daysEqual, monthsEqual), yearsEqual); //Day->Month->Year to efficiently remove as many as possible as soon as possible.
        var whereClause = Expression.Call(typeof(Queryable), "Where", new Type[] { data.ElementType }, data.Expression, Expression.Lambda(allPartsEqual, parameter));
        return data.Provider.CreateQuery<T>(whereClause);
    }
    public static IQueryable<T> WhereDate<T>(this IQueryable<T> data, Expression<Func<T, DateTime?>> selector, DateTime date)
    {
        var selectorMemberExpression = ((MemberExpression)selector.Body);
        var nullableDateProperty = (PropertyInfo)selectorMemberExpression.Member;
        var entityExpression = Expression.Parameter(typeof(T));
        var date1Expression = Expression.Property(entityExpression, nullableDateProperty);
        return data._whereDate(Expression.PropertyOrField(date1Expression, "Value"), entityExpression, date);
    }
    public static IQueryable<T> WhereDate<T>(this IQueryable<T> data, Expression<Func<T, DateTime>> selector, DateTime date)
    {
        var selectorMemberExpression = ((MemberExpression)selector.Body);
        var dateProperty = (PropertyInfo)selectorMemberExpression.Member;
        var entityExpression = Expression.Parameter(typeof(T));
        return data._whereDate(Expression.Property(entityExpression, dateProperty), entityExpression, date);
    }
