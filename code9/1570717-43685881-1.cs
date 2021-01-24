    public static Expression<Func<T, bool>> ContainsPredicate<T>(string memberName, string searchValue)
    {
        var parameter = Expression.Parameter(typeof(T), "m");
        var member = Expression.PropertyOrField(parameter, memberName);
        var body = Expression.Call(
            member,
            "Contains",
            Type.EmptyTypes, // no generic type arguments
            Expression.Constant(searchValue)
        );    
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
