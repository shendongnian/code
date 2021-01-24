    public IActionResult DoSomething()
    {
        bool success=someWork();
        if(success)
        {
            TempData["IsLegit"] = true;
            return RedirectToAction("Success");
        }
        else
        {
            return View();
        }
    }
    
    public IActionResult Success
    {
        if((TempData["IsLegit"]??false)!=true)
            return RedirectToAction("Error");
        //Do your stuff
    }
