    public AcitonResult Create()
    { 
       var vm=new CreateVm();
       vm.Universities= GetUniversities();
       return View(vm);
    }
    private List<SelectListItem> GetUniversities()
    {
        return db.Universitetler
                 .Select(x=>new SelectListItem { Value = x.Id,
                                                 Text = x.Name)
                 .ToList();
    }
