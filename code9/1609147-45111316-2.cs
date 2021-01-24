    [HttpGet]
    [Route("contact")]
    public IActionResult Contact() {
        return View();
    }
    
    [HttpPost]
    [Route("contact")]    
    public IActionResult Contact(string name, string email, string message) {
        ViewBag.Name = name;
        ViewBag.Email = email;
        ViewBag.Message = message;
    
        return View();
    }
