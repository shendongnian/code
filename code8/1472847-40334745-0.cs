    public static class ServiceProviderExtensions
        {
            public static TResult CreateInstance<TResult>(this IServiceProvider provider) where TResult : class
            {
                ConstructorInfo constructor = typeof(TResult).GetConstructors()[0];
                
                if(constructor != null)
                {
                    object[] args = constructor
                        .GetParameters()
                        .Select(o => o.ParameterType)
                        .Select(o => provider.GetService(o))
                        .ToArray();
    
                    return Activator.CreateInstance(typeof(TResult), args) as TResult;
                }
    
                return null;
            }
        }
