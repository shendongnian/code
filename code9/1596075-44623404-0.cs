    public object Load<T>(string propName, T entity) where T : class
    {
    	var property = _context.Set<T>().GetType().GetProperties().SingleOrDefault(p => p.Name.Equals(propName));
    	if(property == null)
    		throw new ArgumentOutOfRangeException(propName);
    	
    	return property.GetValue(entity);
    }
