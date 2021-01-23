    protected List<PropertyInfo> PropertyInfos
    {
        get
        {
            return _propertyInfos
                    ?? (_propertyInfos =
                        GetType()
                            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .Where(prop => 
                                prop.IsDefined(typeof(RequiredAttribute), true) || 
                                prop.IsDefined(typeof(MaxLengthAttribute), true) ||
                                prop.IsDefined(typeof(RegularExpressionAttribute), true) )
                            .ToList());
        }
    }
