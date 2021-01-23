    public ActionResult Index()
    {
        var model = new MyModel();
        model.Posts = Posts; //Posts = new List<string> { "element1", "element2", "element3" };
        return View(model);
    }
