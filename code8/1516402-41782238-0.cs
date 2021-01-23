        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Barcode,Name,Category_id,Comment")] Product product)
        {
            if (ModelState.IsValid)
            {
                var productInDb = db.Products.First(x => x.Id == product.Id);
                productInDb.last_edited = DateTime.Now;
                productInDb.last_edited_from = User.Identity.GetUserId();
                db.Entry(productInDb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_id = new SelectList(db.Category, "Id", "Name", product.Category_id);
            return View(product);
        }
