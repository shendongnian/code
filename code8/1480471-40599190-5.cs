    const string clickCountSessionKey = "clickCount";
    [HttpGet]
    public ActionResult ClickCounter()
    {
        // initialize the model
        var model = new MyModel() { ClickCount = 0 };
        var previousClickCount = Session[clickCountSessionKey];
        if (previousClickCount != null)
        {
            model.ClickCount = (int)previousClickCount;
        }
        return View(model);
    }
    [HttpPost]
    public ActionResult ClickCounter(MyModel model)
    {
        // increment the click count of the model
        model.ClickCount++;
        // track the click count in the session
        Session[clickCountSessionKey] = model.ClickCount;
        return View(model);
    }
