            public class StartController : Controller {
                private readonly MovieRepository movieRepository;
                public StartController()
                {
                    this.movieRepository = new MovieRepository();
                }
            
                // GET: Start
                public ActionResult Index()
                {
                    var movies = movieRepository.GetMoviesFromRepository();
    
                    return View(movies);
                }
                // GET: Details
    
                public ActionResult Movie(int id)
                {
                    var allMovies = movieRepository.GetMoviesFromRepository();
                    var movie = allMovies.FirstOrDefault(x => x.MovieID.Equals(id));
                    return View(movie);
                }
            }
