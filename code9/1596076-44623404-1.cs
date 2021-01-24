    public object Load(string setName)
    {
    	var property = _context.GetType().GetProperties()
    		.SingleOrDefault(p => p.PropertyType.IsGenericType
    					  && p.PropertyType.GetGenericArguments()[0].GetProperty(setName) != null);
    	return property.GetValue(_context) ?? throw new ArgumentOutOfRangeException(setName);
    }
