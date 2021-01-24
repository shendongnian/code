    public ActionResult Index()
	{
	    var model = new MyModel();
	    model.Work = new Work {Phone = "612345678", PhoneInt = 612345678};
        return View(model);
    }
    
