    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Name,Comment")] Product product)
    {
        product.Last_Edited = DateTime.UtcNow;
        if (ModelState.IsValid)
        {           
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(product);
    }
