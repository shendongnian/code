    class Program
    {
    	public class Article
    	{
    		public Article()
    		{
    			Tags = new HashSet<Tag>();
    		}
    
    		public int Id { get; set; }
    		public HashSet<Tag> Tags { get; set; }
    	}
    
    	public class Tag
    	{
    		public Tag()
    		{
    			Articles = new HashSet<Article>();
    		}
    
    		public int Id { get; set; }
    		public HashSet<Article> Articles { get; set; }
    	}
    
    	static void Main(string[] args)
    	{
    
    		List<Article> articles = new List<Article>();
    		List<Tag> tags = new List<Tag>();
    		
    		int n = 100;
    
    		for (int i = 0; i < n; i++)
    		{
    			tags.Add(new Tag() { Id = i });
    		}
    
    		int v = 100;
    
    		Random rnd = new Random();
    
    		for (int i = 0; i < v; i++)
    		{
    			var article = new Article() { Id = i };
    
    			int c = rnd.Next(1,v);
    
    			for (int k = 0; k < c; k++)
    			{
    				var tag = tags[rnd.Next(0, v - 1)];
    
    				article.Tags.Add(tag);
    				tag.Articles.Add(article);
    			}
    
    			articles.Add(article);
    		}
    
    
    		var orderedbyarticles = tags.OrderBy(x => x.Articles.Count).ToList();
    
    		for (int i = 0; i < 100; i++)
    		{
    			System.Console.WriteLine(orderedbyarticles[i].Id);    
    		}
    
    		System.Console.ReadLine();
    	}
    }
