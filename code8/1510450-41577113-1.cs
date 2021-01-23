    public ActionResult Index()
    {
        var model = new MyViewModel();
        List<string> listoflists = new List<string>();
        listoflists.Add("java");
        listoflists.Add("php");
        listoflists.Add("C#");
        model.ListOfLists = listoflists;
        return View(model);
    }
