    public void GetMoviesByCategory()
    	{
    		
    		List<Movies> movies = new List<Movies>();
    		movies.Add(new Movies(){moviename = "A", category = new List<String>(){"1","2"}});
    		movies.Add(new Movies(){moviename = "B", category = new List<String>(){"2","3"}});
    		movies.Add(new Movies(){moviename = "C", category = new List<String>(){"3","4"}});
    		movies.Add(new Movies(){moviename = "D", category = new List<String>(){"1"}});
    		movies.Add(new Movies(){moviename = "E", category = new List<String>(){"4"}});
    		movies.Add(new Movies(){moviename = "F", category = new List<String>(){"1","2","4"}});
    		var result = movies.Select(m => m).Where(p => p.category.Contains("1")).ToList();
    		
    		foreach(var movie in result){
    			Console.WriteLine(movie.moviename);
    		}
    	}
    	public class Movies{
    		
    		public Movies(){}
    		public string moviename {get;set;}
    		public List<string> category {get;set;}
    	}
