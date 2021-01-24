    public class Movies
    {
     List<Movie> Items {get; set; }   
     //...
     //...
    
        public Movie bestMovie<TKey>(Func<Movie,TKey> orderBy = null)
        {
          var compare = orderBy ?? (movie)=> movie.Rating;
          return Items.OrderBy(compare).First()
        } 
    }
