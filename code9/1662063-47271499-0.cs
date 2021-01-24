    class Whatever<TEntity> where TEntity : class
    {
        public static MethodInfo ThenIncludeMethod<TPreviousProperty, TProperty>()
        {
            var query = from m in typeof(EntityFrameworkQueryableExtensions).GetMethods()
                        where m.Name == "ThenInclude" && m.IsGenericMethodDefinition
                        let args = m.GetGenericArguments()
                        where args.Length == 3
                        let tEntityType = args[0]
                        let tPreviousPropertyType = args[1]
                        let tPropertyType = args[2]
                        let parameters = m.GetParameters()
                        where parameters.Length == 2
                        where parameters[0].ParameterType == typeof(IIncludableQueryable<,>).MakeGenericType(new Type[] { tEntityType, tPreviousPropertyType })
                        where parameters[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(new[] { tPreviousPropertyType, tPropertyType }))
                        select m.MakeGenericMethod(new[] { typeof(TEntity), typeof(TPreviousProperty), typeof(TProperty) });
            return query.SingleOrDefault();
        }
        public static MethodInfo ThenIncludeEnumerableMethod<TPreviousProperty, TProperty>()
        {
            var query = from m in typeof(EntityFrameworkQueryableExtensions).GetMethods()
                        where m.Name == "ThenInclude" && m.IsGenericMethodDefinition
                        let args = m.GetGenericArguments()
                        where args.Length == 3
                        let tEntityType = args[0]
                        let tPreviousPropertyType = args[1]
                        let tPropertyType = args[2]
                        let parameters = m.GetParameters()
                        where parameters.Length == 2
                        where parameters[0].ParameterType == typeof(IIncludableQueryable<,>).MakeGenericType(new Type[] { tEntityType, typeof(IEnumerable<>).MakeGenericType(new[] { tPreviousPropertyType }) })
                        where parameters[1].ParameterType == typeof(Expression<>).MakeGenericType(typeof(Func<,>).MakeGenericType(new[] { tPreviousPropertyType, tPropertyType }))
                        select m.MakeGenericMethod(new[] { typeof(TEntity), typeof(TPreviousProperty), typeof(TProperty) });
            return query.SingleOrDefault();
        }
    }
