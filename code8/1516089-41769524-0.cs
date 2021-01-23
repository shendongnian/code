    // GET: Worts/Details
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    
        var wort = (from s in db.Worts
                    where s.ID == id
                    select s).FirstOrDefault();
    
        if (wort == null)
        {
            return HttpNotFound();
        }
    
        return View(wort);
    }
