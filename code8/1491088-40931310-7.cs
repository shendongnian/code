    // ViewModel
    public const string CheckedPropertyName = "Checked";
    private bool _checked = false;
    public bool Checked
    {
    	get
    	{
    		return _checked;
    	}
    
    	set
    	{
    		_checked = value;
    		RaisePropertyChanged(CheckedPropertyName);
    
    		// app logic is handled here
    		if (_checked)
    		{
    			LastName = FirstName;
    		}
    	}
    }
    
    <!-- XAML -->
    <CheckBox IsChecked="{Binding Checked}" />
