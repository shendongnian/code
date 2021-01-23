    [MyActionFilter]
    public ActionResult Test1()
    {
        var vm = new ItemViewModel<DerivedItem1>();
        return View(vm);
    }
    [MyActionFilter]
    public ActionResult Test2()
    {
        var vm = new ItemViewModel<DerivedItem2>();
        return View(vm);
    }
