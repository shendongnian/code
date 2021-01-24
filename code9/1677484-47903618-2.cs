    [HttpPost]
    public ActionResult StartStopTime(Worker worker)
    {
        var viewModel = TempData.Peek("MyViewModel") as ViewModel;
        return RedirectToAction("Index", viewModel);
    }
