    public override bool Equals(object obj)
    {
    	if (obj == null)
    		return false;
    	ConnSrv c = obj as ConnSrv;
    	if (c == null)
    		return false;
    	if (ID == c.ID)
    		return true;
    	return false;
    }
    
    public override int GetHashCode()
    {
    	int result = ID.GetHashCode();
    	return result;
    }
