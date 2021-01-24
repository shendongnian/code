    public ActionResult Delete(string User) 
    {
        var db = new DataContext();
        var u = db.PX.Where(x=> x.Email == User).FirstOrDefault();  //This line updated
        db.PX.Remove(u);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
