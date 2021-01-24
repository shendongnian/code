    public ActionResult Delete(string User) 
    {
    var db = new DataContext();
    var u = db.PX.Where(x=> x.Email == User).FirstOrDefault();   //This line updated
    if (u==null)
    {
        return HttpNotFound();
    }
    return View(u);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(string User)
    {
        var db = new DataContext();
        var u = db.PX.Where(x=> x.Email == User).FirstOrDefault();  //This line updated
        db.PX.Remove(u);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
