    public ActionResult TestConnection(ApplicationSettings model, DatabaseSystems database)
    {
        // at the end, instead of putting return View() or return("Index", model), I used below code
        return Redirect("/[ControllerName]");
    {
