    public static class TypeExtensions
    {
        private static readonly ConcurrentDictionary<PropertyInfo, Delegate> Getters = new ConcurrentDictionary<PropertyInfo, Delegate>();
        private static readonly ConcurrentDictionary<PropertyInfo, Delegate> Setters = new ConcurrentDictionary<PropertyInfo, Delegate>();
        public static Delegate CreateGetter(this PropertyInfo property)
        {
            return Getters.GetOrAdd(property, p =>
            {
                var parameter = Expression.Parameter(p.DeclaringType, "o");
                var delegateType = typeof(Func<,>).MakeGenericType(p.DeclaringType, p.PropertyType);
                var lambda = Expression.Lambda(delegateType, Expression.Property(parameter, p.Name), parameter);
                return lambda.Compile();
            });
        }
        public static Delegate CreateSetter(this PropertyInfo property)
        {
            return Setters.GetOrAdd(property, p =>
            {
                var parameter = Expression.Parameter(p.DeclaringType, "o");
                var valueParm = Expression.Parameter(p.PropertyType, "value");
                var delegateType = typeof(Action<,>).MakeGenericType(p.DeclaringType, p.PropertyType);
                var lambda = Expression.Lambda(delegateType, Expression.Assign(Expression.Property(parameter, p.Name), valueParm), parameter, valueParm);
                return lambda.Compile();
            });
        }
    }
