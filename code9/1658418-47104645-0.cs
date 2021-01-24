    public static Expression<Func<TS, object>>
        GetOrder<TS>(TS entityExample, string propertyName) {
        //Create x=>x.PropName
        var propertyInfo = typeof(TS).GetProperty(propertyName);
        var arg = Expression.Parameter(typeof(TS), "x");
        var property = Expression.PropertyOrField(arg, propertyName);
        var selector = Expression.Lambda<Func<TS, object>>(
                       property, new ParameterExpression[] { arg });
        return selector;
    }
