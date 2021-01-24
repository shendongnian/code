        private static readonly MethodInfo OrderByMethod = typeof(Queryable).GetMethods().Single(method => method.Name == "OrderBy" && method.GetParameters().Length == 2);
        private static readonly MethodInfo OrderByDescendingMethod = typeof(Queryable).GetMethods().Single(method => method.Name == "OrderByDescending" && method.GetParameters().Length == 2);
        static IQueryable<T> OrderByQuery<T>(IQueryable<T> source, string propertyName, SortDirection direction)
        {
            string[] memberTree = propertyName.Split('.');
            Expression ex = null;
            Type currentType = typeof(T);
            ParameterExpression parameterExpression = Expression.Parameter(currentType);
            for (int i = 0; i < memberTree.Length; i++)
            {
                ex = Expression.Property(ex != null ? ex : parameterExpression, memberTree[i]);
            }
            LambdaExpression lambda = Expression.Lambda(ex, parameterExpression);
            MethodInfo genericMethod  =
            direction == SortDirection.Descending
                ? OrderByDescendingMethod.MakeGenericMethod(currentType, ex.Type)
                : OrderByMethod.MakeGenericMethod(currentType, ex.Type);
            object ret = genericMethod.Invoke(null, new object[] { source, lambda });
            return (IQueryable<T>)ret;
        }
