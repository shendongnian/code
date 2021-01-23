    public ActionResult Index(MyModel model)
    {
        if(!Enum.IsDefined(typeof(MyEnum), model.EnumType ?? 0))
        {
            return RedirectToAction("Index", "Home");
        }           
        return View();
    }
