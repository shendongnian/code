    public class HomeController : Controller {
        private readonly IClusterMonitoring monitoring;
        public HomeController(IClusterMonitoring monitoring) {
            this.monitoring = monitoring;
        }
        // GET: Home
        public ActionResult Index() {
            var status = monitoring.GetNameNodeStatus("", new Credential());
            return View(status);
        }
     }
