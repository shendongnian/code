    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(SupportProcessViewModel vm)
    {        
        if (ModelState.IsValid)
        {
            // (1)
            vm.SupportProcess.StartProcess = null;
            // (2)  
            db.Entry(vm.SupportProcess).State = EntityState.Modified;
            // (3)
            db.Entry(vm.SupportProcess).Reference(e => e.StartProcess).Load();
            // (4)
            vm.SupportProcess.StartProcess =
                vm.SelectedStartProcess > 0 ?
                db.SupportProcesses.Find(vm.SelectedStartProcess) :
                null;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(vm);
    }
