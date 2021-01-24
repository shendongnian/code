    [HttpPost]
    public ActionResult _Fav(int ID)
    {
    	List<string> errors = new List<string>(); // You might want to return an error if something wrong happened
    	
    	//Do DB Processing   
    
        return Json(errors, JsonRequestBehavior.AllowGet);
    }
    [HttpPost]
    public ActionResult _UnFav(int ID)
    {
    	List<string> errors = new List<string>(); // You might want to return an error if something wrong happened
    	
    	//Do DB Processing   
    
        return Json(errors, JsonRequestBehavior.AllowGet);
    }
