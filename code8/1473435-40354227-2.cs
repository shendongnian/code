    // GET: Result
    [AllowAnonymous]
    public ActionResult Index(MyModel model)
    {
        // IsValid will check that the Type property is setted and will exectue 
        // the data annotation attribute EnumDataType which check that 
        // the enum value is correct.
        if (!ModelState.IsValid) 
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }
