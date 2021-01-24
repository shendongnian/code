    [HttpPost]
    public ActionResult Create(CreateVm vm)
    {
        if (ModelState.IsValid)
        {
            //read from vm and save
            var k=new kafedra { 
                               UniveristyId=vm.SelectedUniversity, 
                               FacultyId=vm.SelectedFaculty, 
                            };
            db.kafedra.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        vm.Universities= GetUniversities();
        return View(vm);
    }
