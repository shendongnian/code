    public ActionResult Create()
    {
       var vm = new CreateVm();
       //Load the Items property by reading the ProgramVersion table data
       vm.Items = db.ProgramVersions
                   .Select(x=>new SelectListItem { Value=x.Id.ToString(),
                                                   Text=x.Ver} )
                   .ToList();
       return View(vm);
    }
