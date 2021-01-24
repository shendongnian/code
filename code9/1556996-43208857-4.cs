    public class WindowViewModel : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    	
    	/* Remove this:
    	RegisterMode mode = RegisterMode.None;
    	public RegisterMode Mode
    	{
    		get { return this.mode; }
    		set
    		{
    			this.mode = value;
    			RaisePropertyChanged("Mode");
    		}
    	}
    	*/
    	
    	// Use composition instead
    	UCViewModel _ucViewModel = null;
    	public UCViewModel UcViewModel
    	{
    		get 
    		{ 
    			if (_ucViewModel == null)
    			{
    				_ucViewModel = new UCViewModel();
    			}
    			return _ucViewModel; 
    		}
    	}
    
    	void RaisePropertyChanged(string propertyName = "")
    	{
    		if (PropertyChanged != null)
    		{
    			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    }
