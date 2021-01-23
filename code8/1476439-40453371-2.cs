    public ActionResult Index(string searchString)
    {
        var defaultReturnValue = //you default dummy object
    
        if(String.IsNullOrEmpty(searchString))
            return View(defaultReturnValue);
    
        var customers = (from s in db.TicketDetails
                         where s.SupportRef.Contains(searchingString)
                         select s).Take(2).ToList(); // execute query here so not to execute it twice
        
        return View(customers.Count > 1 ? defaultReturnValue :
                                          customers.FirstOrDefault() ?? defaultReturnValue);
    }
