    public static List<T> Sort<T>(IQueryable<T> list, int sortOrder, string sortColumn, Type o)
    {            
        var param = Expression.Parameter(list.ElementType);
        MemberExpression sortProperty = Expression.Property(Expression.Convert(param, o), sortColumn);
         //  etc...
