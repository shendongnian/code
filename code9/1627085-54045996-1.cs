    //
    [HttpGet]
    public PartialViewResult MyPartialView()
    {
        MyPartialViewModel model = new MyPartialViewModel();
        return PartialView("~/Path/To/_myPartialView.cshtml", model);
    }
