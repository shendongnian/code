    [Area("FooArea")]
    public class FooController : Controller
    {
        private readonly IService _service;
        public FooController(IService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return Content(_service.DoThisThing());
        }
    }
    [Area("BarArea")]
    public class BarController : Controller
    {
        private readonly IService _service;
        public BarController(IService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return Content(_service.DoThisThing());
        }
    }
