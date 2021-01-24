    [HttpGet("error")]
    [HttpPost("error")]
    public IActionResult Index()
    {
        return StatusCode(500,"Hello, World! From debug controller");
    }
