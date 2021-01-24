    public class Movies
    {
     public enum ImplementedStrategies{ ImdbRating }
     List<Movie> Items {get; set; }   
     //...
     //...
    
        public Movie bestMovie(ImplementedStrategies strategy = ImplementedStrategies.ImdbRating)
        {
           switch(strategy)
           {
             case ImplementedStrategies.ImdbRating:
               return new ImdbRatingSelection().FindBestMovie(Items);
             default: 
                throw new ArgumentOutOfRangeException(nameof(strategy), strategy, null);
           }
        }
        public Movie bestMovie(IMovieSelection customSelection)
        {
          return customSelection?.FindBestMovie(Items) ?? bestMovie();
        }
    }
