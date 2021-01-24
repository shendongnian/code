    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(SupportProcessViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);   
        {           
        // Get the item
        var sp = db.SupportProcesses.FirstOrDefault(p => p.Id == vm.SupportProcess.ProcessId);
        // Set the new values
        if (vm.SelectedStartProcess > 0)
        {
            sp.StartProcessId = vm.SelectedStartProcess;
        }
        sp.Name = vm.SupportProcess.Name;
        sp.Description = vm.SupportProcess.Description;
        // all the rest values        
        // Save changes
        db.SupportProcesses.Update(sp);
        db.SaveChanges();
        
        return RedirectToAction("Index");
    }    
