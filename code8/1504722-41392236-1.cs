    public ActionResult Add()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Add(IEnumerable<Person> list)
    {
        return View();
    }
