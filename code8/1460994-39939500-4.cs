    [MyActionFilter]
    public ActionResult Test()
    {
        var vm = new ItemViewModel<BaseItem>();
        vm.Item = new DerivedItem1();
        return View(vm);
    }
