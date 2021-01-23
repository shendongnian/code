    public class HomeController : Controller {
        private readonly IClusterMonitoring monitoring;
        public HomeController(IClusterMonitoring monitoring) {
            this.monitoring = monitoring;
        }
        // GET: Home
        public ActionResult Index() {
            string getStatus = monitoring.GetNameNodeStatus("", new Credential());
            return View();
        }
     }
