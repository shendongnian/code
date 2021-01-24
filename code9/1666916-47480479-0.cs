    public class BooksController : Controller
    {
        [Route("books")]
        public ActionResult Index()
        {
            // to do : Get all the books and pass it to the view.
            return View();
        }
        [Route("books/{bookName}")]
        public ActionResult Details(string bookName)
        {
           // to do : Get single book using the bookName parameter
           // and pass that to the view.
           return View();
        }
    }
