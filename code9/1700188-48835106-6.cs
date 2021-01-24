    [HttpPost, Route("bar/index/{color}")]
    public IActionResult Index(string color, List<string> carNames)
    {
        // do stuff...
        return View();
    }
