    private int _myPivotIndex;
    public int MyPivotIndex
    {
    	get
    	{
    		return _myPivotIndex;
    	}
    	set
    	{
    		if (ConditionMet)
    		{
    			_myPivotIndex = value;
    		}
    		else
    		{
    			_myPivotIndex = 0;
    			OnPropertyChanged("MyPivotIndex");
    		}
    	}
    }
