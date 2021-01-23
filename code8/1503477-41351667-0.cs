    public class FooController : Controller
    {
        ...
        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult Navbar()
        {
            var navbar = // retrieve navbar data
            return PartialView("_Navbar", navbar);
        }
    }
