    // GET: Automobili/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobil automobil = db.Automobils.Find(id);
            if (automobil == null)
            {
                return HttpNotFound();
            }
            return View(automobil);
        }
        // POST: Automobili/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AutomobilID,Marka,Model,Godiste,Zapremina_motora,Snaga,Gorivo,Karoserija,Opis,Cena,Kontakt")] Automobil automobil , HttpPostedFileBase productImg/*, int promena*/)
        {
            if (ModelState.IsValid)
            {
                Automobil automobilUBazi = db.Automobils.Find(automobil.AutomobilID);
                if (productImg != null)
                {
                    automobilUBazi.Fotografija = "/Slike/" + fileName;
                }
                db.Entry(automobil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(automobil);
        }
