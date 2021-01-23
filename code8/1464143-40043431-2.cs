    private string _message = null;
    public string Message
    {
    	get
    	{
    		return _message;
    	}
    	set
    	{
    		if (_message == value)
    		{
    			return;
    		}
    
    		_message = value;
    		RaisePropertyChanged(() => Message);
    	}
    }
    private int _count = 0;
    public int Count
    {
    	get
    	{
    		return _count;
    	}
    	set
    	{
    		_count = value;
    		RaisePropertyChanged(() => Count);
    	}
    }
