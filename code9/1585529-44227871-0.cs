    [HttpPost]
    public IActionResult Foo()
    {
        bool isBar = handleFoo();
        if (isBar) return Bar();
        else return View();
    }
    
    
    [HttpPost]
    public IActionResult Bar()
    {
        bool isFoo = handleBar();
        if (isFoo) return Foo();
        else return View();
    }
