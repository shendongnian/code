        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Location,Description,Notes")] Store store)
        {
    
            if (ModelState.IsValid)
            {
                store.CreateDate = DateTime.Now;
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
    
            return View(store);
        }
