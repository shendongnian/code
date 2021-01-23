    // GET: Worts/Details
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    
        var wort = WortService.GetWort(id);
        if (wort == null)
        {
            return HttpNotFound();
        }
    
        return View(wort);
    }
