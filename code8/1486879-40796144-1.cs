    public ActionResult Delete(int? id)
    {
        if (id == null)
            return HttpNotFound();
        var del = db.checkAccounuts.Find(id);
        
        if (del == null)
            return HttpNotFound();
        
        aspnetusers user = db.aspnetusers.find(del.User_Id);
    
        db.checkAccounuts.Remove(del);
        db.aspnetusers.remove(user.ID);
        db.SaveChanges();
        return RedirectToAction("ViewAccounts");
    } 
