    public interface IDataService
    {
    	IList<Article> DownloadArticles();
    }
    
    public class DataService : IDataService
    {
    	public IList<Article> DownloadArticles()
    	{
    		var articles = new List<Article>();
    		// you actually download articles here
    		return articles;
    	}
    }
