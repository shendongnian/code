    Type type = typeof(teamNeeds);
    Expression cond = Expression.Constant(false);
    ParameterExpression par = Expression.Parameter(type);
    ConstantExpression ces = Expression.Constant("Starter");
    foreach (PropertyInfo property in type.GetProperties())
    {
        if (property.PropertyType == typeof(string))
        {
            Expression prop = Expression.Property(par, property.GetMethod);
            Expression eq = Expression.Equal(prop, ces);
            cond = Expression.OrElse(cond, eq);
        }
    }
    Func<teamNeeds, bool> condFunc = Expression.Lambda<Func<teamNeeds, bool>>(cond, par).Compile();
    var result = needs.Where(condFunc).ToList();
