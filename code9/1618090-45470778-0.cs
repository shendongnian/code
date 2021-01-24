    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name="Shrek" };
            //important line
            return View(movie);
        }
    }
