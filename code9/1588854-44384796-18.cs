    [Themed]
    public class PortingController : Controller
    
        private readonly IRepository<Port> _repository;
    
        public PortingController(IRepository<Port> repository) {
            _repository = repository;
        }
    
        [HttpGet]
        public ActionResult Index() {
            // query the table
            var ports = _repository.Table.ToList();
            return View(ports);
        }
    
        [HttpPost]
        public ActionResult AddRequest(port item) {
            if (ModelState.IsValid) {
                _repository.Create(item);
            }
            return RedirectToAction("Index");
        }
    
    }
