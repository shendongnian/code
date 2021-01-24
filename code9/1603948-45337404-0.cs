    public ActionResult Details(string id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    
        Techie techie = db.Techie.Include(f => f.TechieFiles).SingleOrDefault(f => f.ApplicationUserID == id);
    
        if (techie == null)
        {
            return HttpNotFound();
        }
        return View(techie);
    }
