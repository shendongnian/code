    public class Article : INotifyPropertyChanged
    {
    	private string _url;
    	public string Url
    	{
    		get
    		{
    			return _url;
    		}
    		set
    		{
    			_url = value;
    			PropertyChanged("Url");
    		}
    	}
    }
