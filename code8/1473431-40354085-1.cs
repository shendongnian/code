    public ActionResult Index(MyModel model)
    {
        if(!model.EnumType.HasValue)
        {
            return RedirectToAction("Index", "Home");
        }           
        if(!Enum.IsDefined(typeof(MyEnum), model.EnumType))
        {
            return RedirectToAction("Index", "Home");
        }           
        return View();
    }
