    public ActionResult Index()
    {
        return View();
    }
    public async Task<ActionResult> PartialIndex()
    {
        var model = new MyModel();
        await DoSomethingAsync(model);
        return PartialView(model);
    }
    
    private async Task DoSomeAsyncStuff()
    {
        await Task.Delay(20000);
        model.Name = "Something";
        //Assigning other model properties
    }
