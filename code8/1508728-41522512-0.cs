    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Details(Bind(Include = "id,column1")] table2 table2)
    {
    	if (ModelState.IsValid)
    	{
    		db.table2.Add(table2);
    		db.SaveChanges();
    	}
    
    	// You need to re-create object to tables class to pass it to the view.
    	return View(tables);
    }
