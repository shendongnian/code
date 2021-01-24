    public static Func<T, bool> GetWhereLambda<T>(string paramName, dynamic paramValue)
        {            
            var param = Expression.Parameter(typeof(T), "s");
            var classExpr = GetEqualsExpr(param, paramName, paramValue);
            return Expression.Lambda<Func<T, bool>>(classExpr, param).Compile();
        }
        private static Expression GetEqualsExpr(ParameterExpression param,
                                 string property,
                                 dynamic value)
        {
            Expression prop = Expression.Property(param, property);
            Expression val = Expression.Constant(value, prop.Type);
            return Expression.Equal(prop, val);
        }
