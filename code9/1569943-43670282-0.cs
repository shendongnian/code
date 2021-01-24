    public static Expression<Func<TClass, bool>> ConvertParamArgsToExpression<TClass>(string[] args)
    {
        Expression finalExpression = Expression.Constant(true);
        var parameter = Expression.Parameter(typeof(TClass), "x");
        foreach (string arg in args) {
            string[] values = arg.Split('=');
            PropertyInfo prop = typeof(TClass).GetProperty(values[0]);
            if(prop != null)
            {
                Expression expression = null;
                var member = Expression.Property(parameter, prop.Name);
                var constant = Expression.Constant(values[1]);
                expression = Expression.Equal(member, constant);
                finalExpression = Expression.AndAlso(finalExpression, expression);
            }
        }
        return (Expression.Lambda<Func<TClass, bool>>(finalExpression, parameter));
    }
