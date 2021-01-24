    [HttpGet]
    public ActionResult Delete(int? Id)
    {
    	db.Table.Remove(db.Table.Find(Id));
    	db.SaveChanges();
    	return View("Index", db.Table.ToList());
    }
