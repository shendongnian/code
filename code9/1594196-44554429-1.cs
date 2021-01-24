    [HttpPost]
    public ActionResult Create([Bind(Include = "ID,NumbersStore")] MyModel myModel, int[] Numbers)
    {
        foreach(var item in Numbers)
        {
            myModel.Numbers.add(item);
        }
        db.MyModels.Add(myModel);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
