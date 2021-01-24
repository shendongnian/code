    public class LazyMovieService : IMovieService
    {
        private readonly Lazy<IMovieService> lazyInstance;
        public LazyMovieService(Func<IMovieService> instanceFactory)
        {
            lazyInstance = new Lazy<IMovieService>(instanceFactory);
        }
        public string[] GetMovies()
        {
            return lazyInstance.Value.GetMovies();
        }
    }
