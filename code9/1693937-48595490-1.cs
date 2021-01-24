    public ActionResult TopMenu()
    {
        _viewModel.SetMenuFor(SessionManager.matricule);
        return PartialView("~/Views/Shared/_TopMenu.cshtml", _viewModel);
    }
