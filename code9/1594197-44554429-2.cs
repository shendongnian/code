    [HttpPost]
    public ActionResult Create([Bind(Include = "ID,NumbersStore")] MyModel myModel, int[] Numbers)
    {
        // do something with numbers
        db.MyModels.Add(myModel);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
