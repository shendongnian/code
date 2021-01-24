    [HttpGet]
    public ActionResult Index()
    {
    	return View(new YourModel());
    }
    [HttpPost]
    public ActionResult Index( YourModel model)
    {				
    	if(ModelState.IsValid)
    	{
    		//model is valid, add your code here 
    	}
    	else
    	{
            //returns with model validation error
    		return View();
    	}
    			
    }
  
