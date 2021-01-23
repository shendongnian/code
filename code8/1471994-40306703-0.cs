    var index =  propertyLambdaString.IndexOf('.');
    if (index == -1)
    {
        accessor[propertyLambdaString] = value;
        // problem above: throws Exception if assigning value to Nullable<T>
    }
    else
    {
        var property = propertyLambdaString.Substring(0, index);
        accessor = ObjectAccessor.Create(accessor[property]);
        AssignValueToProperty(accessor, value, propertyLambdaString.Substring(index + 1));
    }
