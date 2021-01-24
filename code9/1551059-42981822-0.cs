    public IEnumerable<Movie> Movies
    {
        get
        {
            return this.movies;
        }
    }
    
    var theList = instance.Movies as IList<Movie>();
    if (theList != null) 
        count = theList.Count;
    else 
        count = instance.Movies.Count();
