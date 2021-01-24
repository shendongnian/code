    public ActionResult Index()
    { 
       var model = new myClassViewModel();
       model.selectedLocation = "IT"; // as rene stated
       return View(model);
    }
