    private string _informativeMessage;
    public string InformativeMessage
    {
    	get { return _informativeMessage; }
    	set
    	{
    		if (_informativeMessage != value)
    		{
    			if(value == SomeValueThatMakesMeNeedToChangeIt)
    			{
    				_informativeMessage = "Overridden Value";
    			}
    			else
    			{
    				_informativeMessage = value;
    			}
    			
    			RaisePropertyChanged();
    		}
    	}
    }
