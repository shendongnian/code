        /// <summary>
        /// Takes include looks like 'x => x.Collections.Select(o => o.List.Select(p => p.Date))'
        /// </summary>
        public static IQueryable<T> GetQueryWithIncludes<T>(IQueryable<T> query, Expression<Func<T, object>> arg)
        {
            // Tiny optimization
            ParameterInfo[] parameters;
            var includeInfo = typeof(EntityFrameworkQueryableExtensions).GetMethods().Where(info => info.Name == "Include" &&
                (parameters = info.GetParameters()).Length == 2 &&
                typeof(Expression).IsAssignableFrom(parameters[1].ParameterType)).Single();
            // Retrive then include that take first param as 'IIncludableQueryable<TEntity, ICollection<TPreviousProperty>>'
            var thenIncludeInfo = typeof(EntityFrameworkQueryableExtensions).GetMethods().Where(info => info.Name == "ThenInclude").ToList()[1];
            // Retrive then include that take first param as 'IIncludableQueryable<TEntity, IEnumerable<TPreviousProperty>>'
            var lastThenIncludeInfo = typeof(EntityFrameworkQueryableExtensions).GetMethods().Where(info => info.Name == "ThenInclude").ToList()[0];
            // Retrive all selection from input expression
            var lambda = arg as LambdaExpression;
            var method = arg.Body as MethodCallExpression;
            var result = new List<Expression>();
            while (method != null)
            {
                result.Add(Expression.Lambda(method.Arguments[0], lambda.Parameters[0]));
                lambda = method.Arguments[1] as LambdaExpression;
                method = lambda.Body as MethodCallExpression;
            }
            result.Add(lambda);
            // Add Include and ThenInclude to IQueryable
            for (int i = 0; i < result.Count; ++i)
            {
                var lambdaExp = result[i] as LambdaExpression;
                query = i == 0
                    ? includeInfo.MakeGenericMethod(lambdaExp.Parameters[0].Type, lambdaExp.ReturnType).Invoke(null, new object[] { query, lambdaExp }) as IQueryable<T>
                    : i == result.Count - 1
                        ? lastThenIncludeInfo.MakeGenericMethod((result[0] as LambdaExpression).Parameters[0].Type, lambdaExp.Parameters[0].Type, lambdaExp.ReturnType).Invoke(null, new object[] { query, lambdaExp }) as IQueryable<T>
                        : thenIncludeInfo.MakeGenericMethod((result[0] as LambdaExpression).Parameters[0].Type, lambdaExp.Parameters[0].Type, lambdaExp.ReturnType).Invoke(null, new object[] { query, lambdaExp }) as IQueryable<T>;
            }
            return query;
        }
