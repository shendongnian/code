    if (value != null && value.GetType() != propertyInfo.PropertyType
    	// to T[]
    	&& propertyInfo.PropertyType.IsArray && propertyInfo.PropertyType.GetArrayRank() == 1
    	// from List<T>
    	&& value.GetType().IsGenericType
    	&& value.GetType().GetGenericTypeDefinition() == typeof(List<>)
    	&& value.GetType().GetGenericArguments()[0] == propertyInfo.PropertyType.GetElementType())
    {
    	// List<T>.ToArray()
    	var toArray = value.GetType().GetMethod("ToArray", Type.EmptyTypes);
    	var array = toArray.Invoke(value, null);
    	propertyInfo.SetValue(obj, array);
    	return;
    }
