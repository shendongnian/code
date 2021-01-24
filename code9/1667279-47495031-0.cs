    public class Movies
    {
     List<Movie> Items {get; set; }
     IComparable<Movie> DefaultImplementation = new DefaultCompareImplementation();
     //...
     //...
    
        public Movie bestMovie(IComparable<Movie> comparer = null)
        {
          var compare = comparer ?? DefaultImplementation;
          return Items.Sort(compare).First()
        } 
    }
