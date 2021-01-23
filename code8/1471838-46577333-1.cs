    public class HomeController : Controller
    {
        public ObjectResult Index()
        {
            //General checks
            return Ok(new IndexDataModel() { Property = "Data" });
        }
        public ViewResult IndexView()
        {
            //View specific checks
            return View(new IndexViewModel(Index()));
        }
    }
