    public ActionResult Submit(FormCollection formCollection)
    {
        if (User.IsInRole("SuperAdmin") || User.IsInRole("Worker"))
        {
            ...
        }
      
        if (User.IsInRole("Admin"))
        { 
            //do some admin tasks
        }
      
        return RedirectToAction("Index", "Tasks");
    }
