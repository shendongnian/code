    public IEnumerable<string> Settings
    {
    	get
    	{
    		return GetType()
    			.GetProperties().Where(p => p.PropertyType == typeof(bool) 
                                             && (bool)p.GetValue(this, null));
                .Select(o => nameof(o));
    	}
    }
