    [HttpGet]
    public ActionResult RetournerPostes()
    {
        return View();
    }
    
    [HttpPost]
    public ActionResult RetournerPostes(string avion, 
        [ModelBinder(typeof(CommaSeparatedModelBinder))] int[] types)
    {
        return View();
    }
