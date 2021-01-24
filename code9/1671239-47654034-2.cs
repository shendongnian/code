    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult doSomething(Something obj)
    {
        //use web service and get string URL
        string urlString = ;// get from the web service response.
    
        if (!string.IsNullOrEmpty(urlString))
        {
            //if the url is from within the domain.
            return RedirectToAction(urlString);
          //if the url is from other domain use this
          //return Redirect(urlString);
        }
    
        //If the urlString is empty Return to a error page
        return View("Error");
    }
