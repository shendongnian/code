    public static class Utility
    {
        //makes expression for specific prop
        public static Expression<Func<TSource, object>> GetExpression<TSource>(string propertyName)
        {
            var param = Expression.Parameter(typeof(TSource), "x");
            Expression conversion = Expression.Convert(Expression.Property
            (param, propertyName), typeof(object));   //important to use the Expression.Convert
            return Expression.Lambda<Func<TSource, object>>(conversion, param);
        }
    
       
        public static IOrderedQueryable<TSource> 
        OrderBy<TSource>(this IQueryable<TSource> source, string propertyName)
        {
            return source.OrderBy(GetExpression<TSource>(propertyName));
        }
    }
