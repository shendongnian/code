    public ActionResult Details(SubjectOverviewViewModel model)
    {
        // This will be a POST action
        // Notice the parameter here is SubjectOverviewModel. 
        // Normally this will be passed in after the user has filled our some 
        // form. You will perform validation here and if it is valid, then you 
        // will save it to the datasource (database etc.). 
        // Once you save to the database send a redirect (RedirectToAction) to 
        // tell the user everything was successful. Use the PRG pattern here.
        return View(model);
    }
