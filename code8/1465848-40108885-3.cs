    public class Class1<T1>
    {
        private static readonly Func<T1> _factory;
    
        static Class1() {
            if (!typeof(SomeBaseClass).IsAssignableFrom(typeof(T1)))
            {
                _factory = () => default(T1);
                return;
            }
    
            var ctor = typeof(T1).GetConstructor(Array.Empty<Type>());
            var newExpression = Expression.New(ctor);
    
            _factory = Expression.Lambda<Func<T1>>(newExpression).Compile();
        }
    
        public static object GetObj()
        {
            return _factory();
        }
    }
