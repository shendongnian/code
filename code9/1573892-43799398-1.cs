    var filters = new Dictiontionary<string, object>();
    IEnumerable<SampleClass> query = listOfSampleClasses;
    
    // we will loop through the filters
    foreach(filter in filters)
    {
        // find the property of a given name
        var property = typeof(SampleClass).GetProperty(filter.Key, BindingFlags.Instance | BindingFlags.Public);
        if (property == null) continue;
    
        // create the ParameterExpression
        var parameter = Expression.Parameter(typeof(SampleClass));
        // and use that expression to get the expression of a property
        // like: x.SampleProperty1
        var memberExpression = Expression.Property(parameter, property);
        
        // Convert object type to the actual type of the property
        var value = Convert.ChangeType(filter.Value, property.PropertyType, CultureInfo.InvariantCulture);
        
        // Construct equal expression that compares MemberExpression for the property with converted value
        var eq = Expression.Equal(memberExpression, Expression.Constant(value));
    
        // Build lambda expresssion (x => x.SampleProperty == some-value)
        var lambdaExpression = Expression.Lambda<Func<SampleClass, bool>>(eq, parameter);
    
        // And finally use the expression to filter the collection
        query = query.Where(lambdaExpression);
    }
    
    var filteredList = query.ToList();
