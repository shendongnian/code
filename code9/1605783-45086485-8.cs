    [HttpGet]
    public ActionResult Create() {
        var model = new Collector();
        model.MyList.Add(new TestModel());
        return View(model);
    }
