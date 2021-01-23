                [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase IMG, [Bind(Include = "CatName,CatDesc")] T_Categorie t_Categorie)
        {
            if (ModelState.IsValid)
            {
                db.T_Categorie.Add(t_Categorie);
                db.SaveChanges();
                var addedCategory = db.T_Categorie.Find(t_Categorie.CatName);
                return RedirectToAction("FileUpload", "T_Images", new { image = IMG, CurrentCat = addedCategory });
            }
            return View(t_Categorie);
        }
