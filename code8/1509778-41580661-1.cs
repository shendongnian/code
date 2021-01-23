    [ChildActionOnly]
    public ActionResult Parameters()
    {
        var model = dal.GetParameters().OrderBy(x => x.ParameterName).Select(x => new ParameterVM()
        {
            Name = x.ParameterName,
            HasRange = ... // set defaults for other properties as required
        }).ToList();
        return PartialView("_Parameters", model);
    }
