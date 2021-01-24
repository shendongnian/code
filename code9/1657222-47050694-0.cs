    public IActionResult Index()
    {
        var files = HttpContext.Request.Form.Files;
    
        return View();
    }
