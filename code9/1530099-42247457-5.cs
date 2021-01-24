    [Area("Admin")]  
    public class AdminController : Controller
    {     
      public IActionResult Index()
      {
        return View();
      }
    
      public IActionResult Testing()
      {
        return Content("Testing area!");
      }
    }
