    private static System.Func<T, T, T> CompileAdd<T>()
    {
        // Declare the parameters
        System.Linq.Expressions.ParameterExpression paramA =
            System.Linq.Expressions.Expression.Parameter(typeof(T), "a");
        System.Linq.Expressions.ParameterExpression paramB =
            System.Linq.Expressions.Expression.Parameter(typeof(T), "b");
        // Add the parameters
        System.Linq.Expressions.BinaryExpression body =
            System.Linq.Expressions.Expression.Add(paramA, paramB);
        // Compile it
        System.Func<T, T, T> add =
            System.Linq.Expressions.Expression.Lambda<System.Func<T, T, T>>
            (body, paramA, paramB).Compile();
        return add;
    }
    private static System.Func<T, T, T> CompileSubtract<T>()
    {
        // Declare the parameters
        System.Linq.Expressions.ParameterExpression paramA =
            System.Linq.Expressions.Expression.Parameter(typeof(T), "a");
        System.Linq.Expressions.ParameterExpression paramB =
            System.Linq.Expressions.Expression.Parameter(typeof(T), "b");
        // Subtract the parameters
        System.Linq.Expressions.BinaryExpression body =
            System.Linq.Expressions.Expression.Subtract(paramA, paramB);
        // Compile it
        System.Func<T, T, T> subtract =
            System.Linq.Expressions.Expression.Lambda<System.Func<T, T, T>>
            (body, paramA, paramB).Compile();
        return subtract;
    }
    private static T GetMinValue<T>()
    {
        return (T)GetConstValue(typeof(T), "MinValue");
    }
    private static T GetMaxValue<T>()
    {
        return (T)GetConstValue(typeof(T), "MaxValue");
    }
    private static object GetConstValue(System.Type t, string propertyName)
    {
        System.Reflection.FieldInfo pi = t.GetField(propertyName, System.Reflection.BindingFlags.Static
            | System.Reflection.BindingFlags.Public
            | System.Reflection.BindingFlags.NonPublic
            );
        return pi.GetValue(null);
    }
    private static TSigned MapUnsignedToSigned<TUnsigned, TSigned>(TUnsigned ulongValue)
    {
        TSigned signed = default(TSigned);
        unchecked
        {
            System.Func<TSigned, TSigned, TSigned> f = CompileAdd<TSigned>();
            signed = f((TSigned)(dynamic)ulongValue, GetMinValue<TSigned>());
        }
        return signed;
    }
    private static TUnsigned MapSignedToUnsigned<TSigned, TUnsigned>(TSigned longValue)
    {
        TUnsigned unsigned = default(TUnsigned);
        unchecked
        {
            System.Func<TSigned, TSigned, TSigned> subtract = CompileSubtract<TSigned>();
            unsigned = (TUnsigned)(dynamic)subtract(longValue, GetMinValue<TSigned>());
        }
        return unsigned;
    }
