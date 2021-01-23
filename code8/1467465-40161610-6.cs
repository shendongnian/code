    // GET: /<controller>/
    public IActionResult Index()
    {
        var model = new IndexViewModel();
        model.Customers = _context.Customers.ToList();
        model.Devices = _context.Devices.ToList();
        return View(model);
    }
