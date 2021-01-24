    [HttpGet]
    public IActionResult Foo()
    {
        bool isBar = handleFoo();
        if (isBar) return RedirectToAction("Bar");
        else return View();
    }
    
    
    [HttpPost]
    public IActionResult Bar()
    {
        bool isFoo = handleBar();
        if (isFoo) return RedirectToAction("Foo");
        else return View();
    }
