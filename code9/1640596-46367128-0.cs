    [HttpPost]
    public ActionResult Register(User obj)
    {
        if (ModelState.IsValid)
        {
            DatabaseEntities db = new DatabaseEntities();
            db.Users.Add(obj);
            db.SaveChanges();
        }
        return View(obj);
    }
