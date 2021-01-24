    [HttpPost]
    public ActionResult StartStopTime(Worker worker)
    {
        var viewModel = TempData["MyViewModel"] as ViewModel;
        return RedirectToAction("Index", viewModel);
    }
