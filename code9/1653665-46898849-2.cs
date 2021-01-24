    public ActionResult Create()
    {
        var vm = new MyViewModel();
        vm.ExceptionVms = new List<ExceptionVm>()
        {
            new ExceptionVm() {Id = 1, ShiftDate = DateTime.Now.AddDays(-3)},
            new ExceptionVm() {Id = 2, ShiftDate = DateTime.Now.AddDays(-2)},
            new ExceptionVm() {Id = 3, ShiftDate = DateTime.Now.AddDays(-1)}
        };
        return View(vm);
    }
