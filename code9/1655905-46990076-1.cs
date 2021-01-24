    public ActionResult ListCollege()
    {
        var vm = new CollageSelectionVm () ;
        vm.Collages = db.Collages
                        .Select(x=>new SelectListItem { Value = x.Id.ToString(),
                                                        Text=x.Name })
                        .ToList();
        return View(vm);
    }
