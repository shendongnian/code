    public static Func<T[], T> CreateLambda<T>(int num)
    {
        var parameter = Expression.Parameter(typeof(T[]), "p");
    
        // We sum all the parameters together
        Expression sum = Expression.ArrayIndex(parameter, Expression.Constant(0));
    
        for (int i = 1; i < num; i++)
        {
            sum = Expression.Add(sum, Expression.ArrayIndex(parameter, Expression.Constant(i)));
        }
    
        Expression body = sum;
    
        var exp = Expression.Lambda<Func<T[], T>>(body, parameter);
        return exp.Compile();
    }
