    public const string SelectedItemPropertyName = "SelectedItem";
    private DataItem _selectedItem = null;
    public DataItem SelectedItem
    {
    	get
    	{
    		return _selectedItem;
    	}
    	set
    	{
    		if (_selectedItem == value)
    		{
    			return;
    		}
    
    		_selectedItem = value;
    		RaisePropertyChanged(SelectedItemPropertyName);
    	}
    }
