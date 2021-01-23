    public class VehiclesController : Controller
    {
        // GET: Vehicles
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NewVehicleViewModel vm)
        {
            return View();
        }
    }
