    public class StartController : Controller
    {
        List<Movie> movieList = new List<Movies>()
        {
            new Movies() { Title = "Terminator", Genre = "Action", Year = 1984, Country = "America" },
            new Movies() { Title = "Terminator II", Genre = "Action", Year = 1984, Country = "America" }
        };
     
        // GET: Start
        public ActionResult Index()
        {
            return View(movieList);
        }
        public ActionResult Movie(string title)
        {
            var movie = movieList.Where(x => x.Title == title).FirstOrDefault();
            return View(movie);
        }
    }
