    namespace WebApplication1.Controllers
    {
        public class HomeController : Controller
        {
            public IActionResult Index()
            {
                var model = new Employee()
                {
                    Salary = 1000
                };
    
                return View(model);
            }
        }
    }
