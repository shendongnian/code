    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "MyId,MyObject, MyObject.Number, MyObject.Name")]MyViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
    }
