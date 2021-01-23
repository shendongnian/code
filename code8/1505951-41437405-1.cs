    public class HomeController : Controller
    {
        public ActionResult PostForm(string myFormValue)
        {
            return View("Index");
        }
