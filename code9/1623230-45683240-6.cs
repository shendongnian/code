    public class MemoizedAttribute : Attribute { }
    
    public class Memoizer<TArg, TResult> : IInterceptor
    {
        private readonly ConcurrentDictionary<TArg, TResult> cache;
        public Memoizer(IEqualityComparer<TArg> comparer = null)
        {
            cache = new ConcurrentDictionary<TArg, TResult>(comparer ?? EqualityComparer<TArg>.Default);
        }
        public void Intercept(IInvocation invocation)
        {
            var memoized = invocation.Method.GetCustomAttribute<MemoizedAttribute>();
            if (memoized != null)
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
    }
