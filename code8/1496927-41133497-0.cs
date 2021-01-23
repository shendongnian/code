    void Main()
    {
    	using (WebClient wc = new WebClient())
    	{
    		var json = wc.DownloadString("https://newsapi.org/v1/articles?source=business-insider&sortBy=top&apiKey=f47672429b7044a29e7a4671f9f41c28");
    		var obj = JsonConvert.DeserializeObject<RootObject>(json);
    		Console.WriteLine(obj.articles[0].title);
    	}
    }
    
    
    	public class Article
    {
    	public string author { get; set; }
    	public string title { get; set; }
    	public string description { get; set; }
    	public string url { get; set; }
    	public string urlToImage { get; set; }
    	public string publishedAt { get; set; }
    }
    
    public class RootObject
    {
    	public string status { get; set; }
    	public string source { get; set; }
    	public string sortBy { get; set; }
    	public List<Article> articles { get; set; }
    }
