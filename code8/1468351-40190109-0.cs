    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("~/Default.aspx");
        }   
    }
