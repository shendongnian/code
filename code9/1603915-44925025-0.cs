    public ActionResult Edit(string id) {
      ApplicationDbContext db = new ApplicationDbContext();
      ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == id);
      return View(user);
    }
