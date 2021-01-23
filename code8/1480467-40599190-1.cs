    [HttpGet]
    public ActionResult ClickCounter()
    {
        var model = new MyModel();
        // initialize the model
        model.ClickCount = 0;
        return View(model);
    }
    [HttpPost]
    public ActionResult ClickCounter(MyModel model)
    {
        // increment the click count of the model
        model.ClickCount++;
        return View(model);
    }
