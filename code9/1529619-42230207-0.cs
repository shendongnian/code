    public ActionResult Index ()
    {
        SearchBarViewModel model = new SearchBarViewModel();
        var searchvalues = GetALLSearchValuesFromDb();
        model.Color = searchvalues.Where(sv => sv.Name == "Color");
        model.Size = searchvalues.Where(sv => sv.Name == "Size");
        model.Shape = searchvalues.Where(sv => sv.Name == "Shape");
        return View(model)
    }
