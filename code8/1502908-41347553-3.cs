    [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                dbBooks.Entry(BAmodel.book).State = EntityState.Modified;
                dbBooks.Entry(BAmodel.author).State = EntityState.Modified;
                
                dbBooks.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }
