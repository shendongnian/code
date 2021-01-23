    [HttpPost]
    [Route("quotes")]
    public IActionResult Index(Home model)
    {
       if (!ModelState.IsValid)
            return View(); 
       // to do :continue saving
    }
