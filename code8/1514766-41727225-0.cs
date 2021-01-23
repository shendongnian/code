    public ActionResult Edit(int performanceId)
    {
        var model = db.Performances.FirstOrDefault(m => m.PerformanceId == performanceId);
        return View(model);
    }
    
    [HttpPatch] //Or, more commonly, [HttpPost], but an update technically aligns with Patch, not Post.
    public ActionResult Edit(CustomPerformancePerformersModel model)
    {
        if (ModelState.IsValid)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
