    [HttpPost]
    public ActionResult Create([Bind(Include = "ID,Numbers")] MyModel myModel)
    {
        // do something with numbers
    
        db.MyModels.Add(myModel);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
