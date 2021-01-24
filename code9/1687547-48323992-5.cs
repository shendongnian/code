    dynamic ObjectToPopulate = new List<string> { "foo" };
    PropertyInfo[] PopulatedObjectProperties;
    Type genericType = GetGenericTypeOfEnumerable(ObjectToPopulate);
    if (genericType != null)
    {
        PopulatedObjectProperties = genericType.GetProperties();
    }
    else
    {
        PopulatedObjectProperties = ObjectToPopulate.GetType().GetProperties();
    }
