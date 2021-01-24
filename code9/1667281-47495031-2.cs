    public class ImdbRatingSelection:IMovieSelection 
    {
       public Movie FindBestMovie(IEnumerable<Movie> items)
        {
           return items.OrderBy(movie=>movie.Rating).FirstOrDefault();
        }
    }
    
