    [ChildActionOnly]
    public ActionResult MyPartialViewName(string firstName, string lastName)
    {
    // create model here...
     return View(mypartialViewModel);
    }
