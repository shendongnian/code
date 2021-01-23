    public ActionResult Create([Bind(Include = "Id, name")] Init init,
                               [Bind(Include = "Id")] Form form)
    {
    
        if (ModelState.IsValid)
        {
            db.Init.Add(init);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(init);
    } 
