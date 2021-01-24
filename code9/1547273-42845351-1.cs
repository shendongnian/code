    if (value != null && value.GetType() != propertyInfo.PropertyType
    	// from T[]
    	&& value.GetType().IsArray && value.GetType().GetArrayRank() == 1
    	// to List<T>
    	&& propertyInfo.PropertyType.IsGenericType
    	&& propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>)
    	&& propertyInfo.PropertyType.GetGenericArguments()[0] == value.GetType().GetElementType())
    {
    	var T = value.GetType().GetElementType();
    	var listT = typeof(List<>).MakeGenericType(T);
    	// new List<T>(IEnumerable<T> items)
    	var enumerableT = typeof(IEnumerable<>).MakeGenericType(T);
    	var newListT = listT.GetConstructor(new Type [] { enumerableT });
    	var list = newListT.Invoke(new[] { value });
    	propertyInfo.SetValue(obj, list);
    	return;
    }
