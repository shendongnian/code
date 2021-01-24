    public class ViewBase :INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	protected void NotifyPropertyChanged(string info)
    	{		
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
    	}
    }
    
    public class MProject : ViewBase
    {
    	public string Name
    	{
    		get
    		{
    			return _name;
    		}
    		set
    		{
    			if (value != _name)
    			{
    				_name = value;
    				NotifyPropertyChanged(nameof(Name));
    			}
    		}
    	}
    	private string _name;
    	
    	...
    }
