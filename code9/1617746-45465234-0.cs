    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind] SimpleEmailEditVM vm)
    {
        var itemToEdit = db.Find(vm.Id);
        //Make sure Id is valid
        if(itemToEdit == null) return BadRequest();
        //Make sure user can edit this object
        if(!User.IsInRole("CanEditItems")) return Forbidden();  
        if(itemToEdit.AllowedUser != User.Identity.Name) return Forbidden(); 
        if (ModelState.IsValid)
        {
            /* find the correct address from db and update the
               fields specified in the viewmodel? */
            db.Entry(address).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(address);
    }
