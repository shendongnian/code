    public static class ExpressionHelper{
            //Contains for Enumerable Type
            public static Expression DynamicContains<TProperty>(this ParameterExpression argument, string property, IEnumerable<TProperty> items)
            {
                var propertyExp = Expression.Property(argument, property);
                var ce = Expression.Constant(items);
    
                var call = Expression.Call(typeof(Enumerable), "Contains", new[] { propertyExp.Type }, ce, propertyExp);
    
                return call;
            }
    
            //Contains for String type
            public static Expression StringContains(this ParameterExpression argument, string property, string propertyValue)
            {
                var propertyExp = Expression.Property(argument, property);
                var toLower = Expression.Call(propertyExp, typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));
                MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                var value = Expression.Constant(propertyValue.ToLower(), typeof(string));
                var call = Expression.Call(toLower, method, value);
                return call;
            }
    
    }
