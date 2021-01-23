    public class SlugController : Controller {
        public ActionResult SluggedUrl(string slug) {
            ViewBag.Message = "Your " + slug;
    
            return View();
        }
    }
