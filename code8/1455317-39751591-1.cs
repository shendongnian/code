    public class StartController : Controller
    {
        // This could later comes from Database. 
        public IList<Movie> Movies
        {
            get
            {
                var movies = new List<Movie>
                {
                    new Movie {Id = 1, Title = "Terminator", Genre = "Action", Year = 1984, Country = "America"},
                    new Movie {Id = 2, Title = "Terminator II", Genre = "Action", Year = 1984, Country = "America"}
                };
                return movies;
            }
        }
    
        // GET: Start
        public ActionResult Index()
        {
            return View(Movies);
        }
    
        public ActionResult Movie(int id)
        {
            var movie = Movies.FirstOrDefault(m => m.Id == id);
            return View(movie);
        }
    }
