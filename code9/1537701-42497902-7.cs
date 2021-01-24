    public class CacheResultInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var cacheAttribute = invocation.Method.GetCustomAttribute<CacheAttribute>();
            if (cacheAttribute != null)
            {
                Trace.WriteLine($"Found a [Cache] attribute on the {invocation.Method.Name} method with a duration of {cacheAttribute.Duration}.");
            }
            invocation.Proceed();
        }
    }
