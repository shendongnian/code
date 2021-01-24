    bool _isBusy = true;
    public bool IsBusy
    {
    	get
    	{
    		return _isBusy;
    	}
    	set
    	{
    		_isBusy = value;
    		OnPropertyChanged(nameof(IsBusy));
    	}
    }
