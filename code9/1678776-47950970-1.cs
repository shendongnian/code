    public class pojo : INotifyPropertyChanged
    {
    
    	private string _prefix;
    	private int _year;
    
    	public string Prefix
    	{
    		get => _prefix;
    		set
    		{
    			if (_prefix == value) return;
    			_prefix = value;
    			OnPropertyChanged(nameof(PeriodName));
    		}
    	}
    	public int Year
    	{
    		get => _year;
    		set
    		{
    			if (_year == value) return;
    			_year = value;
    			OnPropertyChanged(nameof(PeriodName));
    		}
    	}
    	public string PeriodName => _prefix + '-' + (_year % 100).ToString(); 
    
    	public event PropertyChangedEventHandler PropertyChanged;
    	void OnPropertyChanged(string prop)
    	{
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    	}
    }
