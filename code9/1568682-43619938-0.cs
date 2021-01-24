    [HttpGet]
    public ActionResult Index(ImportData model)
    {
        return View(model);
    }
    
    [HttpPost]
    public ActionResult Index(MyModel model)
    {
        if (...error...)
        {
            model.SetErrorState();
            ModelState.AddModelError("ProcessError", "error message");
            return View(model);
        }
        else
        {
            // do something...
            model.SetSuccessState();
            return View(model);
        }
    }
