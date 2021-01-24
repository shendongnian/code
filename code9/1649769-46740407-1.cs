    [HttpGet]
    public ActionResult Index()
    {
        return View(new MainModel() { PartialModel1 = new PartialModel1(), PartialModel2 = new PartialModel2 });
    }
