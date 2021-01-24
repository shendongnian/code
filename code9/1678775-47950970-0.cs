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
    			OnPropertyChanged();
    		}
    	}
    	public int Year
    	{
    		get => _year ;
    		set
    		{
    			if (_year == value) return;
    			_year = value;
    			OnPropertyChanged();
    		}
    	}
    	public int QuarterNo { get; set; }
    	public int SerialNo { get; set; }
    	public string From { get; set; }
    	public string To { get; set; }
    	public string PeriodName { get; set; }
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	private void OnPropertyChanged([CallerMemberName] string property = "")
    	{
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    	}
    
    }
