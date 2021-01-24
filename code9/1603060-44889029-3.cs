    public ActionResult Create([Bind] A stuff)
    {
        if (ModelState.IsValid)
        {
            db.A.Add(A);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(stuff);
    }
