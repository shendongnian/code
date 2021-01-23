    private IEnumerable<LambdaExpression> CreateExpressions(Type fooType)
    {
        foreach (var property in fooType.GetProperties())
        {
            ParameterExpression pe = Expression.Parameter(fooType, "x");
            MemberExpression me = Expression.Property(pe, property.Name);
            yield return Expression.Lambda(Expression.Convert(me, typeef(object)), pe);
        }
    }
