    public static IMemberConfiguration<TSource, TDestination> IgnoreAll<TSource, TDestination>(
        this IMemberConfiguration<TSource, TDestination> config)
    {
        // First we'll get the collection of properties to iterate over.
        var props = typeof (TDestination).GetProperties();
        foreach (var prop in props)
        {
            // Get the property information.
            var propertyInfo = typeof(TDestination).GetProperty(prop.Name);
            // Create an expression that points to the property.
            var entityParameter = new ParameterExpression[]
            {
                Expression.Parameter(typeof(TDestination), "e")
            };
            var propertyExpression = Expression.Property(entityParameter[0], prop);
            // Create a Func<,> using the TDestination and the property's type
            // for the Type parameters.
            var funcType = typeof(Func<,>).MakeGenericType(typeof(TDestination), propertyInfo.PropertyType);
            // We need to create an Expression using Expression.Lambda<>, but we
            // don't know the types involved so we have to do this using reflection.
            var lambdaMethod = typeof (Expression)
                    .GetMethods()
                    .Single(m => m.IsGenericMethod &&
                                 m.GetParameters()[0].ParameterType == typeof(Expression) &&
                                 m.GetParameters()[1].ParameterType == typeof(ParameterExpression[]));
            var lambdaMethodConstructed = lambdaMethod.MakeGenericMethod(funcType);
            var expression = lambdaMethodConstructed.Invoke(
                    null,
                    new object[] { propertyExpression, entityParameter });
            // Now we need to construct the Ignore method using the property's Type.
            var ignoreMethod = config.GetType().GetMethod("Ignore");
            var constructed = ignoreMethod.MakeGenericMethod(propertyInfo.PropertyType);
            // Finally, we call the constructed Ignore method, using
            // our expression as the argument.
            constructed.Invoke(config, new object[] { expression });
        }
        return config;
    }
