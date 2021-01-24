    public virtual bool IsSubclassOf(Type c)
    {
    	Type type = this;
    	if (type == c)
    	{
    		return false;
    	}
    	while (type != null)
    	{
    		if (type == c)
    		{
    			return true;
    		}
    		type = type.BaseType;
    	}
    	return false;
    }
