    DerivedClassForInterface ConvertToClassForInterface<T>(T t)
    {
        DerivedClassForInterface result = new DerivedClassForInterface();
        Type resultType = typeof(DerivedClassForInterface);
        PropertyInfo[] properties = typeof(T).GetProperties();
        foreach (var property in properties)
        {
            var propToSet = resultType.GetProperty(property.Name);
            if (propToSet.SetMethod != null)
            {
                propToSet.SetValue(result, property.GetValue(t));
            }
        }
        return result;
    }
