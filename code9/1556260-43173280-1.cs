    public IEnumerable<Movie> GetByYear(int _year)
    {
       this.MoviesLibrary.Where(movie => movie.MovieId == _movieId);
        return this;
    }
