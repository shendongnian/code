    static Expression<Func<Application, T>> BuildTupleSelector<T>(
        string paramType, Func<T> usedForGenericTypeInference)
    {
        var m = Expression.Parameter(typeof(Application), "m");
        var body = Expression.New(typeof(T).GetConstructors().Single(),
            new Expression[] {
                Expression.PropertyOrField(m, nameof(Application.ApplicationId)),
                Expression.PropertyOrField(m, paramType)
            },
            new MemberInfo[]
            {
                typeof(T).GetProperty("ApplicationId").GetGetMethod(),
                typeof(T).GetProperty("Value").GetGetMethod()
            });
        return Expression.Lambda<Func<Application, T>>(body, m);
    }
