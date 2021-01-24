    static class ExtensionMethods
	{
		static public void CopyTo(this object source, object destination)
		{
			var destinationType = destination.GetType();
			
			foreach (var s in source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
			{
				var d = destinationType.GetProperty(s.Name);
				if (d == null) continue;   //No matching property
				if (!d.CanWrite) continue; //Property found, but is read only
				if (!d.PropertyType.IsAssignableFrom(s.PropertyType)) continue; //properties are not type-compatible
				d.SetValue(destination, s.GetValue(source));
			}
		}
	}
