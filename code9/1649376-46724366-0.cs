    [HttpPost]
    public ActionResult MyAction(MyContainer container)
    {
       var id = container.Id;
       foreach(Filter filter in container.Filters)
       {
           //Do something
       }
    }
