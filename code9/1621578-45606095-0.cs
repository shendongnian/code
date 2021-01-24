    public async Task<ActionResult> Index()
    {
        var model = new MyModel();
        await DoSomeAsyncStuff(model);
        return View(model);
    }
    
    private async Task DoSomeAsyncStuff(MyModel model)
    {
        await Task.Delay(20000);
        model.Name = "Something";
        //Assigning other model properties
    }
