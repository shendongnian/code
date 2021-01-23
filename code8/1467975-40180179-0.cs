    public class ContentController : Controller
    {
        // GET: Content
        [AllowAnonymous]
        public ActionResult Index()
        {
            return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Not Found");
        }
    }
