    var parameter = Expression.Parameter(typeof(int));
    var predicate = Expression.Lambda<Func<SomeType, bool>>(
        Combine<SomeType, SomePropertyType>(
            "=",
            c => c.Id,
            Expression.Constant(150497)
        ), parameter);
    
    BinaryExpression Combine<T, TResult>(string op, Func<T, TResult> left, Expression right)
    {
        Expression<Func<T, TResult>> exrpression = arg => left(arg);
        switch (op)
        {
            case "=":
                return Expression.Equal(exrpression, right);
            case "<":
                return Expression.LessThan(exrpression, right);
            case ">":
                return Expression.GreaterThan(exrpression, right);
        }
        return null;
    }
