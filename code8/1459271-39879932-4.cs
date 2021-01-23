    [HttpPost]
    public ActionResult Edit(MyModel model)
    {
    	if (ModelState.IsValid)
    	{
    		var entry = _db.MyModels.SingleOrDefault(m => m.ID == model.ID);
    		if(entry != null)
    		{
    			entry.Accepted = model.Accepted;
    			_db.SaveChanges();
    			
    			return RedirectToAction("Index");
    		}
    	}
    	
    	return View(myModel);
    }
