	public static object[] GetPropertyAttributes<TObject, TProperty>(
		this TObject instance,
		Expression<Func<TObject, TProperty>> propertySelector)
	{
		//consider handling exceptions and corner cases
		var propertyName = ((PropertyInfo)((MemberExpression)propertySelector.Body).Member).Name;
		var property = instance.GetType().GetProperty(propertyName);
		return property.GetCustomAttributes(false);
	}
	public static T GetFirst<T>(this object[] input) where T : Attribute
	{
		//consider handling exceptions and corner cases
		return input.OfType<T>().First();
	}
