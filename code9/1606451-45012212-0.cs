    public ActionResult Index()
    {
      var model = new Review()
            {
                Body = "Start",
                Rating=5
            };
        TempData["ModelName"] = model;
        return RedirectToAction("About");
    }
    public ActionResult About() 
    {     
        var model= TempData["ModelName"];     
        return View(model); 
    } 
