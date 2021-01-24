        public class QueryFilters
        {
            internal static IDictionary<Type, List<LambdaExpression>> Filters { get; set; } = new Dictionary<Type, List<LambdaExpression>>();
            
            public static void RegisterQueryFilter<T>(Expression<Func<T, bool>> expression)
            {
                List<LambdaExpression> list = null;
                if (Filters.TryGetValue(typeof(T), out list) == false)
                {
                    list = new List<LambdaExpression>();
                    Filters.Add(typeof(T), list);
                }
                list.Add(expression);
            }
        }
