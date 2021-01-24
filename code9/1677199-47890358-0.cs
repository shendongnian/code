    static Expression<Func<IEnumerable<string>, bool>> containsExpr = en => en.Contains(null);
    static MethodInfo containsMethodInfo = ((MethodCallExpression)containsExpr.Body).Method.GetGenericMethodDefinition();
    public static Expression In(this Expression value, Expression arrayOfValues)
    {
        return Expression.Call(containsMethodInfo.MakeGenericMethod(arrayOfValues.Type.GetElementType()),
                arrayOfValues, value);
    }
    public static Expression NotIn(this Expression value, Expression arrayOfValues)
    {
        return Expression.Not(In(value, arrayOfValues));
    }
