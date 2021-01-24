    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(ModelClass1 ModelClass1)
    {
        if (ModelState.IsValid)
        {
            db.Attach(ModelClass1);
            db.Entry(ModelClass1).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(ModelClass1);
    }
