	public List<string> GetChangedProperties<T>(object A, object B)
	{
		if (A != null && B != null)
		{
			var type = typeof(T);
			var allProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
			var allSimpleProperties = allProperties.Where(pi => pi.PropertyType.IsSimpleType());
			var unequalProperties =
				   from pi in allSimpleProperties
				   let AValue = type.GetProperty(pi.Name).GetValue(A, null)
				   let BValue = type.GetProperty(pi.Name).GetValue(B, null)
				   where AValue != BValue && (AValue == null || !AValue.Equals(BValue))
				   select pi.Name;
			return unequalProperties.ToList();
		}
		else
		{
			throw new ArgumentNullException("You need to provide 2 non-null objects");
		}
	}
