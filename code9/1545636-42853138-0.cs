    public class JqueryDataTableQueryBuilder
    {
        private static readonly MethodInfo OrderByMethod = typeof(Queryable)
            .GetMethods().
            Single(method => method.Name == "OrderBy"
                && method.GetParameters().Length == 2);
        private static readonly MethodInfo OrderByDescendingMethod = typeof(Queryable)
            .GetMethods().Single(method => method.Name == "OrderByDescending"
                && method.GetParameters().Length == 2);
        public static IQueryable<T> BuildQuery<T>(IQueryable<T> query, DTParameterModel dtParameters)
        {
            IQueryable<T> q = query;
            //I skiped regex search
            var searchColumns = dtParameters.Columns.Where(c => c.Searchable).Select(c => c.Name).ToArray();
            if (searchColumns.Length > 0)
                if (!string.IsNullOrEmpty(dtParameters.Search.Value) && !string.IsNullOrWhiteSpace(dtParameters.Search.Value))
                {
                    int i = 0;
                    var par = Expression.Parameter(typeof(T), "x");
                    Expression exp = Expression.Constant(false);
                    //we need to bind search expressions with 'OR'
                    while (i < searchColumns.Length)
                    {
                        var expNext = GetSearchExpression<T>(searchColumns[i], dtParameters.Search.Value,par);
                        var expInvoke = Expression.Invoke(expNext, par);
                        exp = Expression.OrElse(exp, expNext.Body);
                        i++;
                    }
                    var ex = Expression.Lambda<Func<T, bool>>(exp,par);
                    q = q.Where(ex);
                }
            // order by 
            DTColumn[] columns = dtParameters.Columns.ToArray();
            foreach (var order in dtParameters.Order)
            {
                var orderColumn = columns[order.Column].Name;
                var dir = order.Dir;
                q = OrderByQuery(q, orderColumn, dir);
            }
            return q;
        }
        public static object GetDTResult<T>(DTParameterModel dtParameters, IQueryable<T> query,Expression<Func<T,object>> func = null)
        {
            var totalRecords = query.Count();
            query = query.Skip(dtParameters.Start).Take(dtParameters.Length);
            object data = func == null ? (object) query.ToArray() : query.Select(func).ToArray();
            var result = new
            {
                draw = dtParameters.Draw,
                recordsFiltered = totalRecords,
                recordsTotal = totalRecords,
                data = data
            };
            return result;
        }
        static Expression<Func<T, bool>> GetSearchExpression<T>(string propertyName, string propertyValue,ParameterExpression p)
        {
            var propertyExp = Expression.Property(p, propertyName);
            // we need to call string.Contains method
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var valueExp = Expression.Constant(propertyValue, typeof(string));
            var containsMethodExp = Expression.Call(propertyExp, method, valueExp);
            return Expression.Lambda<Func<T, bool>>(containsMethodExp, p);
        }
        static IQueryable<T> OrderByQuery<T>(IQueryable<T> source, string propertyName, string dir)
        {
            IQueryable<T> query = source;
            Type entityType = typeof(T);
            if (entityType.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) == null)
                throw new NullReferenceException("order by " + propertyName);
            ParameterExpression paramterExpression = Expression.Parameter(entityType);
            Expression orderByProperty = Expression.Property(paramterExpression, propertyName);
            LambdaExpression lambda = Expression.Lambda(orderByProperty, paramterExpression);
            MethodInfo genericMethod = !string.IsNullOrEmpty(dir) && !string.IsNullOrWhiteSpace(dir) && dir.ToUpper().Equals("DESC")
                ? OrderByDescendingMethod.MakeGenericMethod(entityType, orderByProperty.Type)
                : OrderByMethod.MakeGenericMethod(entityType, orderByProperty.Type);
            object ret = genericMethod.Invoke(null, new object[] { query, lambda });
            return (IQueryable<T>)ret;
        }
    }
