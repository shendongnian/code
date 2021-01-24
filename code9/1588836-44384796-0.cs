    [Themed]
    public class PortingController : Controller
    
        private readonly IRepository<port> _repository;
    
        public PortingController(IRepository<port> repository) {
            _repository = repository;
        }
    
        [HttpGet]
        public ActionResult Index() {
            // query the table
            var ports = _portRepository.Table.ToList();
            return View(ports);
        }
    
        [HttpPost]
        public ActionResult AddRequest(port item) {
            _repository.Create(item);
            return RedirectToAction("Index");
        }
    
    }
