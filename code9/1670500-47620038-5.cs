    public ActionResult New()
    {
       var vm= new SendFaxVm();
       vm.Employees = db.Employees
                        .Select(a => new SelectListItem() {Value = a.Id.ToString(),
                                                           Text = a.Name})
                        .ToList();
       return View(vm);
    }
