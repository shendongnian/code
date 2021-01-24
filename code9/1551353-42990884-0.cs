    public static Dictionary<string, string> GetDisplayNameList<T>()
    {
    	var info = TypeDescriptor.GetProperties(typeof(T))
    		.Cast<PropertyDescriptor>()
    		.Where(p => p.Attributes.Cast<Attribute>().Any(a => a.GetType() == typeof(RequiredAttribute)))
    		.ToDictionary(p => p.Name, p => p.DisplayName);
    	return info;
    }
