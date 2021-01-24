    void Main()
    {
    	var films = new List<Movie> {
    		new Movie("Hero",1990 ),
    		new Movie("Titanic",1997 ),
    		new Movie("Mission impossible",1996 ),
    	};
    	
    	foreach(var film in films)
    	{
    		Console.WriteLine(film.GetCompleteTitle());
    	}
    }
    
    
    class Movie
    {
        public String Title { get; }
        public Int32 Year { get; }
    
    	public Movie(String title, Int32 year) => (Title, Year) = (title, year);
    
        public String GetCompleteTitle() => $"{Title} ({Year})";
    }
