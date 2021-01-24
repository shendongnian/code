    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Index(CalculationModel model)
    {
        model.Result = model.Number * model.Number;
        model.Processed = true;
        return View(model);
    }
