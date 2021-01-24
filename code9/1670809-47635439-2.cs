    public class HomeController : Controller
    {
        private readonly IUserAccessHelper userAccessHelper;
        public HomeController(IUserAccessHelper userAccessHelper) 
        {
            this.userAccessHelper = userAccessHelper;
        }
        public ActionResult Create()
        {
           // you can use this.userAccessHelper.IsInRole("abc")
           // to do  :return something
        }
    }
