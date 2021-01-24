    [HttpPost]
    public Create(User user)
    {
        if (!ModelState.IsValid)
        {
           return View(user);
        }
        db.User.Add(user);
        db.SaveChanges();
        return View("Index");
    }
