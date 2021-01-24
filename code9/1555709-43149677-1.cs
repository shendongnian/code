        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SupportProcessViewModel vm)
        {
            if (ModelState.IsValid)
            {              
    
          if (vm.SelectedStartProcess > 0)
          {
            vm.SupportProcess.StartProcess = db.SupportProcesses.Find(vm.SelectedStartProcess);
          }
            db.SupportProcess.Attach(vm.SupportProcess);
            db.Entry(vm.SupportProcess).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(vm);
    }
