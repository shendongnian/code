	static IEnumerable<PropertyInfo> GetPropertiesWithAttribute<TType, TAttribute>()
	{
		Func<PropertyInfo, bool> matching = 
				property => property.GetCustomAttributes(typeof(TAttribute), false)
				                    .Any();
		return typeof(TType).GetProperties().Where(matching);
	}
