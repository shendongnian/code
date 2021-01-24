    public ActionResult SomeAction(string email){
    	// You can also construct model 
    	ViewBag.Email = email;
    	// Return view
    	return View("SomeViewName");
    }
