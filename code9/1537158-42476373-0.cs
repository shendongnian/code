    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind()] Class1 entity) {
        if (ModelState.IsValid) {
            db.Entry(entity).State = EntityState.Modified;
    	foreach(Class2 child in Class1.Classes2)
    	{
            // If has Id...
    		db.Entry(child).State = EntityState.Modified;
    		// If no Id...
    		// db.Entry(child).State = EntityState.Added;
    		// Or if required...
    		// db.Entry(child).State = EntityState.Deleted;
    	}
            db.SaveChanges();
        }
        return View();
    }
