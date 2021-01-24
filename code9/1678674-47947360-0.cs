    public ActionResult Index() {
    
        if (User.IsInRole("Admin")) { return View("Admin");}
        else {return View("Viewer");
    }
