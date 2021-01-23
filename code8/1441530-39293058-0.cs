    public string _SocketInfo;
    
    public string SocketInfo
    {
    	get
    	{
    		if(_SocketInfo == null)
    		{
    			1. load this device sockets from the database - later on apply caching for performance.
    			2. format the contents of _SocketInfo string based on the Socket objects returned by 1. 
    		}
    		return _SocketInfo;
    	}
    }
