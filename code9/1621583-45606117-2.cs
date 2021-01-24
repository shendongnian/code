    public ActionResult Index()
    {
        var model = new MyModel();
    
        return View(model);
    }
    
    public async Task<ActionResult> DoSomeAsyncStuff()
    {
        var model = new MyModel();
        await Task.Delay(20000);
    
        model.Name = "Something";
        //Assigning other model properties
    
        return PartialView("_InnerView", model);
    }
