    public ActionResult Create()
    {
       ViewModel model = new ViewModel();
       model.MyPart = //populate your Part details class
       model.MyAssembly = //populate your Assembly details class
      
       return View(model); //return your view with two classes on one class
    }
