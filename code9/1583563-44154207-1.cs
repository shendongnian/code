    public ActionResult Details(ViewModel vm)
    {
        // Other logic to get details
        vm.SampleNo++;
        return View(vm);
    }
