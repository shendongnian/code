    // GET: Zoekitem/Create
        public ActionResult Create()
        {
            FAQDBConnection FAQconnection = new FAQDBConnection();
            var getlist = FAQconnection.Categorie.ToList();
            SelectList list = new SelectList(getlist, "ID", "Naam");
            ViewBag.categorieBag = list;
            return View();
        }
        // POST: Zoekitem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Zoekitem zoekitem, string catID, string catNaam)
        {
            if (ModelState.IsValid)
                {
                    db.Zoekitem.Add(zoekitem);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            return View(db.Categorie.ToList());
        }
