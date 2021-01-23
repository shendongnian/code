    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Leerling ll)
    {
        var login = (from l in db.myLogin
                      where id == l.leerlingId
                      select l).FirstOrDefault();
        if(login != null)
        {
           db.myLogin.Remove(login);
           db.Entry(ll).State = System.Data.Entity.EntityState.Deleted;
           db.SaveChanges();
        }
        
        return RedirectToAction("Index");// het record verwijderen en redirecten als het gelukt is
    }
