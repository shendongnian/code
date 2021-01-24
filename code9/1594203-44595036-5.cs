    public ActionResult Create([Bind(Include = "ID,Numbers")] MyModel myModel) // Notice name attribute in Bind 
    {
        if (ModelState.IsValid)
        {
            db.MyModels.Add(myModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    
        return View(myModel);
    }
