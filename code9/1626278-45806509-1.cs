    [HttpPost]
    public ActionResult Save(ViewModel model)
    {
       Save(model);
       var newModel = new ViewModel();
       ViewBag.ReportId = 5; // Change 5 for some code that get report id.
       return View(Index, newModel); 
    }
