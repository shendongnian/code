    public TOutput Execute<TOutput>(Func<TOutput> func, ExceptionType exceptionType)
    {
        var policy = GetPolicyFromExceptionType(exceptionType);
        return policy.Execute(func);
    }
    public void Execute(Action action, ExceptionType exceptionType)
    {
        var policy = GetPolicyFromExceptionType(exceptionType);
        policy.Execute(action);
    }
