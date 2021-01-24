    public class HomeController : Controller
        {
            private IRepository repository;
    
            public HomeController(IRepository repo)
            {
                repository = new MemoryRepository();
            }
    
            public IActionResult Index()
            {
                return View(repository.Cities);
            }
    
        }
