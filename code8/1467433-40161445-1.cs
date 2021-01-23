    public bool IsValid()
    {
    	if (string.IsNullOrWhiteSpace(this.Age))
    	{
    		return false;
    	}
    	
    	return true;
    }
