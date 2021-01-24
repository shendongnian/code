    public class SampleController : Controller
    {
        public ActionResult IndexA(string id)
        {
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IndexA()
        {
            return RedirectToRoute("routeA", new { action = "Confirmation" });
        }
        public ActionResult Confirmation()
        {
            return View("Confirmation");
        }
        public ActionResult IndexB(string id)
        {
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IndexB()
        {
            // Note that changing this one to RedirectToRoute is not strictly
            // necessary, but may be more clear to future analysis of the configuration.
            return RedirectToRoute("routeB", new { action = "Confirmation" });
        }
    }
