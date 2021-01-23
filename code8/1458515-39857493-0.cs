    public class Movie
    {
       public int MinAge {get;set;}
       public string Name{get;set;}
    }
    var Movies = new List<Movie>{new Movie{Name = "blahblah", MinAge = 18}};
    //create the list of movies with the age information
    var filtered = (from m in Movies where m.MinAge >= 18 select m).ToList();
