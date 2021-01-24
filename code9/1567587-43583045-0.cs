    public ActionResult EditItem(H_Table item)
    {
        if(ModelState.IsValid)
        {
            using (var db = new YourDbContext())
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges(); 
            }
            return RedirectToAction("Index");
        }
    }
