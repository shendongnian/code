    public class NetworksController : Controller
    {
        private readonly ChoirAdminContext db;
        public NetworksController(ApplicationContext context)
        {
            db = context;
        }
            
        public JsonResult Index()
        {
            return Json(db.Networks);
        }
    }
