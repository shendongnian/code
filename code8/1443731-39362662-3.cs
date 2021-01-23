    public async Task<ActionResult> Index()
    {
        ViewBag.SomeData = await _myService.GetList();
        return View();
    }
