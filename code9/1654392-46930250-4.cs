    public class HomeController : Controller
        {
            private IRepository repository;
    
            public HomeController()
            {
                repository = new MemoryRepository();
            }
    
            public IActionResult Index()
            {
                return View(repository.Cities);
            }
    
        }
