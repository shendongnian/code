    public class RedirectController : Controller
    {
        public ActionResult Index(string redirectToAction, string redirectToController)
        {
            return this.RedirectToActionPermanent(redirectToAction, redirectToController);
        }
    }
