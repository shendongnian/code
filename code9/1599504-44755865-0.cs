    [HttpPost]
    public ActionResult ProcessPreferences(string categoryTag, string userEmailAddr)
    {
        ...
    
        var response = acs.SendRequest("GET", getParameters);
    
        return Content(response, "application/json");
    }
