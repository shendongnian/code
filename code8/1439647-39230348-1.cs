    [HttpGet]
    public ActionResult Display(int id)
    {
        var snip = db/* connection string */.TableName.Find(id);
        return View(snip);
    }
