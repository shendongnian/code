    private static readonly MethodInfo Contains = typeof(string).GetMethod(nameof(string.Contains));
    public static Expression<Func<Student,bool>> SearchPredicate(IEnumerable<string> properties, string searchText) {
        var param = Expression.Parameter(typeof(Student));
        var search = Expression.Constant(searchText);
        var components = properties
            .Select(propName => Expression.Call(Expression.Property(param, propName), Contains, search))
            .Cast<Expression>()
            .ToList();
        // This is the part that you were missing
        var body = components
            .Skip(1)
            .Aggregate(components[0], Expression.OrElse);
        return Expression.Lambda<Func<Student, bool>>(body, param);
    }
