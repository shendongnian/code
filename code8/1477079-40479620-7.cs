    //Get Action for rendering view
    public ActionResult SearchAct()
    {
        return View();
    }
    	
    	
    [HttpPost]
    public ActionResult SearchAct(string nameToFind)
    {
        ViewBag.SearchKey = nameToFind;
    
        return View();
    }
