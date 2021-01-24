    public ActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public ActionResult ProcessForm1(FormOneData data)
    {
        // process form
        return View("Index");
    }
    [HttpPost]
    public ActionResult ProcessForm2(FormTwoData data)
    {
        // process form
        return View("Index");
    }
