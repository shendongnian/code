    public class AutoMap<T> : ClassMap<T>
    {
    	public AutoMap()
    	{
    		var properties = typeof(T).GetProperties();
    		// map the name property first
    		var nameProperty = properties.FirstOrDefault(p => p.Name == "Name");
    		if (nameProperty != null)
    			MapProperty(nameProperty).Index(0);
    		foreach (var prop in properties.Where(p => p != nameProperty))
    			MapProperty(prop);
    	}
    	private MemberMap MapProperty(PropertyInfo pi)
    	{
    		var map = Map(typeof(T), pi);
    		// set name
    		string name = pi.Name;
    		var unitsAttribute = pi.GetCustomAttribute<UnitsAttribute>();
    		if (unitsAttribute != null)
    			name = $"{name} {unitsAttribute.Unit}";
    		map.Name(name);
    		// set default
    		var defaultValueAttribute = pi.GetCustomAttribute<DefaultValueAttribute>();
    		if (defaultValueAttribute != null)
    			map.Default(defaultValueAttribute.Value);
    		
    		return map;
    	}
    }
