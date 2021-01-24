    public ActionResult New()
    {
        return View(viewModel);          // New.cshtml
    }
    [HttpPost]
    public ActionResult Create(Customer customer)
    {
        return View();                   // Create.cshtml
    }
    
