    public ActionResult Details(int Id)
    {
        _db = new ApplicationDbContext();
        Event user = _db.Events.First(u => u.Id == Id);
        return View(user);
    }
