    [HttpGet]
    public ActionResult Update(int id)
    {
        var parameter = db/* connection string variable */.TableName.Find(id);
        return View(parameter);
    }
