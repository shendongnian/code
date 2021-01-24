    public class TempController : BaseController
    {
        private IBaseClass baseClass;
        public HomeController(IBaseClass productService)
        {
            this.baseClass = productService;
            this.baseClass.SetController(this);
        }
        public override string RandomValue
        {
            get
            {
                return "Random value from Derived Class.";
            }
        }
        public ActionResult Index()
        {
            this.baseClass.Method1();
            ViewBag.Title = "Home Page";
            return View();
        }
    }
