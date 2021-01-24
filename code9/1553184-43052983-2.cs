    public class HomeController : Controller {
        
        private readonly ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Test()
        {
            var list = context.Students.ToList();
            return View(list);
        }
    }
    
