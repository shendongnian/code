    [Route("/api/hello")]
    public SomeController : Controller {
        [HttpGet]
        public IActionResult Get() { }
        [HttpGet("something")]
        public IActionResult GetSomething() { }
    }
