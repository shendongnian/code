    public ActionResult Test(string parameterName)
    {
        ViewModelSample model = new ViewModelSample();
        model.Value = parameterName;
        return View(model);
    }
