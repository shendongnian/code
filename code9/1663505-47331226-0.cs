	private static void SetPropValue(ref DraftTask src, string propName, object value)
	{
		var property = src.GetType().GetProperty(propName);
		var valueToSet = Convert.ChangeType(value, property.PropertyType);
		property.SetValue(src, valueToSet);
	}
