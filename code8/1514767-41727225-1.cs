    public ActionResult Edit(int performanceId)
    {
        var model = db.Performances.FirstOrDefault(m => m.PerformanceId == performanceId);
        return View(model);
    }
    
    [HttpPost] //[HttpPatch] is technically correct, but most people I see tend to use only GET and POST actions.
    public ActionResult Edit(CustomPerformancePerformersModel model)
    {
        if (ModelState.IsValid)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
