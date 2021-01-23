    public class DataService
    {
    	private static DataService _instance;
    	public static DataService Instance
    	{
    		get
    		{
    			if (_instance == null)
    			{
    				_instance = new DataService();
    			}
    
    			return _instance;
    		}
    	}
    
    	public IList<Articles> DownloadArticles()
    	{
    		// ...
    	}
    }
    public void Execute(object parameter)
    {
    	var articles = _DataService.Instance.DownloadArticles();
    	Articles = new ObservableCollection(articles);
    }
