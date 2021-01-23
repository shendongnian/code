    public class HomeController : BaseController {
        public HomeController(IUnitOfWork UnitOfWork, IApplicationManager appManager)
            : base(appManager) {
            this.UnitOfWork = UnitOfWork;
        }
        public ActionResult Index() {
            return View("Index");
        }
    } 
