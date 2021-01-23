    public ActionResult Create()
    {
        var viewModel = new UniversityApp.Models.Student();
        return View(viewModel);
    }
