    public ActionResult Tool1(Guid? guid)
    {
        return CommonAction(guid, "Tool1");
    }
    public ActionResult Tool2(Guid? guid)
    {
        return CommonAction(guid, "Tool2");
    }
    private ActionResult CommonAction(Guid? guid, string viewName)
    {
        var model = _viewModelFactory.CreateViewModel<Guid?, ToolsViewModel>(id);
        return model.ReferenceFound ?
            View(model) : View("~/Views/Tools/InvalidReference.cshtml", model);
    }
