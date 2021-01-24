    void Main()
    {
    	var films = new[] {
    		new Movie("Hero",1990 ),
    		new Movie("Titanic",1997 ),
    		new Movie("Mission impossible",1996 ),
    	};
    			
    	foreach(var film in films)
    	{
    		film.Print();
    	}
    }
    
    
    class Movie
    {
        public String Title { get; private set; }
        public Int32 Year { get; private set; }
    
    	public Movie(String title, Int32 year)
    	{
    		Title = title;
    		Year = year;
    	}
    
        public void Print()
        {
    		Console.WriteLine($"{Title} ({Year})");
        }
    }
