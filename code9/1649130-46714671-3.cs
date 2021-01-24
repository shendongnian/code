    public class HomeController : Controller
    {
        // implicit get
        public IActionResult Index() => View();
        // explicit get
        [HttpGet]
        public IActionResult GetAction() => View();
        // extra info
        [HttpPost(Name = "some name", Order = 5)]
        public IActionResult PostAction() => View();
        [HttpPut]
        [HttpDelete]
        [HttpPatch("my template", Name = "patch name", Order = 333)]
        public IActionResult MultiAction() => View();
    }
