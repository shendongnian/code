    /// <summary>
    /// Retrieves a list of all properties with attributes required for <see cref="IDataErrorInfo" /> automation.
    /// </summary>
    protected List<PropertyInfo> PropertyInfos
    {
        get
        {
            return _propertyInfos
                   ?? (_propertyInfos =
                       GetType()
                           .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                           .Where(prop => prop.IsDefined(typeof(ValidationAttribute), true))
                           .ToList());
        }
    }
