    public class BaseViewModel : IBaseViewModel, INotifyPropertyChanged
    {
    	private bool tooltipsEnabled;
    
    	public bool TooltipsEnabled
    	{
    		get { return tooltipsEnabled; }
    		set
    		{
    			tooltipsEnabled = value;
    			NotifyPropertyChanged("TooltipsEnabled");
    		}
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	protected void NotifyPropertyChanged(string info)
    	{
    		if (PropertyChanged != null)
    		{
    			PropertyChanged(this, new PropertyChangedEventArgs(info));
    		}
    	}
    }
