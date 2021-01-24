    class MemoizedAttribute : Attribute { }
    
    class Memoizer<TArg, TResult> : IInterceptor
    {
        private readonly ConcurrentDictionary<TArg, TResult> cache;
        public Memoizer(IEqualityComparer<TArg> comparer = null)
        {
            cache = new ConcurrentDictionary<TArg, TResult>(comparer ?? EqualityComparer<TArg>.Default);
        }
        public void Intercept(IInvocation invocation)
        {
            if (!IsApplicable(invocation))
            {
                invocation.Proceed();
            }
            else
            {
                invocation.ReturnValue = cache.GetOrAdd((TArg)invocation.GetArgumentValue(0),
                    _ =>
                    {
                        invocation.Proceed();
                        return (TResult)invocation.ReturnValue;
                    }
                );
            }
        }
        private bool IsApplicable(IInvocation invocation)
        {
            var method = invocation.Method;
            var isMemoized = method.GetCustomAttribute<MemoizedAttribute>() != null;
            var parameters = method.GetParameters();
            var hasCompatibleArgType = parameters.Length == 1 && typeof(TArg).IsAssignableFrom(parameters[0].ParameterType);
            var hasCompatibleReturnType = method.ReturnType.IsAssignableFrom(typeof(TResult));
            return isMemoized && hasCompatibleArgType && hasCompatibleReturnType;
        }
    }
