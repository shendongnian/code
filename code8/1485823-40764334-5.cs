    public class PerformanceServiceFactory
    {
        private static ConcurrentDictionary<Type, ConstructorInfo> Constructors
                = new ConcurrentDictionary<Type, ConstructorInfo>();
        public static object Create(Type type, PerformanceContext perfContext)
        {
            ConstructorInfo ctor;
            if(Constructors.TryGetValue(type, out ctor))
            {
                return InvokeConstructor(ctor, perfContext);
            }
            else if (type.IsSubclassOf(typeof(PerformanceMonitoredService))
                ||type.IsAssignableFrom(typeof(PerformanceMonitoredService)))
            {
                ConstructorInfo newCtor = type.GetConstructor( 
                    new[] { typeof(PerformanceContext) }
                );
                if(Constructors.TryAdd(type, newCtor))
                {
                    return InvokeConstructor(newCtor, perfContext);
                } else if(Constructors.TryGetValue(type, out ctor))
                {
                    return InvokeConstructor(ctor, perfContext);
                }
            }
            throw new ArgumentException(
                $"Expected type inheritable of {typeof(PerformanceMonitoredService).Name}"}",
                "type");
        }
        private static object InvokeConstructor(ConstructorInfo ctor,
                PerformanceContext perfContext)
        {
            return ctor.Invoke(new object[] { perfContext });
        }
    }
