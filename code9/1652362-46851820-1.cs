    // POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(ModelClass1 ModelClass1)
    {
        if (ModelState.IsValid)
        {
            ModelClass1 entityFromDB = db.ModelClass1
               .Include(i => i.ModelClass2.Select(c => c.ModelClass3))
               .Where(x => x.Id == id)
               .Single();
            MapProperties(entityFromDB, ModelClass1); // You could use a mapper (Auto Mapper)
            db.Entry(ModelClass1).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(ModelClass1);
    }
