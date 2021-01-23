    public ActionResult test(int PrimaryID)
    {
        var testing = db.TableName.Find(PrimaryID);
        // db = Whatever the variable holding your connection string is.. maybe DbContext
        // TableName = Whatever table in your database that holds the record you want
        // This will return the specific object that you are looking for
        return View(testing);
    }
