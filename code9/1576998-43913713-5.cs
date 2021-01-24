	using System.Reflection;
	
	public static object GetPropertyValue(object obj, string propertyName)
	{
		PropertyInfo property = obj.GetType().GetProperty(propertyName);
		return property.GetValue(obj);
	}
