	private static bool CheckIfAnyNavigationHasData<T>(object o, DbContext context) where T : class
	{
		var objectContext = ((IObjectContextAdapter)context).ObjectContext;
		var elementType = objectContext.CreateObjectSet<T>().EntitySet.ElementType;
		var navigations = elementType.DeclaredNavigationProperties;
		var collectionNavigations = typeof(T).GetProperties().Where(w => w.PropertyType.Name.Equals(typeof(ICollection<>).Name)
																	|| w.PropertyType.Name.Equals(typeof(HashSet<>).Name)
																	|| w.PropertyType.Name.Equals(typeof(IList<>).Name))
																	.Join(navigations, t => t.Name, n => n.Name, (t, n) => t).ToArray();
		foreach (var property in collectionNavigations)
		{
			var p = o.GetType().GetProperty(property.Name);
			if (p == null)
				continue;
			var propertyValue = p.GetValue(o);
			if (propertyValue == null)
				continue;
			if ((int)property.PropertyType.GetMethod("get_Count").Invoke(propertyValue, null) > 0)
				return true;
		}
		return false;
	}
