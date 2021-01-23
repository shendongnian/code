    [HttpPost]
    public ActionResult Register(UserVIewModel reg) {
        if (ModelState.IsValid)
        {
            if (db.Users.Where(u => u.UserName == reg.UserName).Any())
            {
               //Do what do u need to do...
            }
            else
            {
              var m = new User {
                UserName = reg.UserName,
                Email = reg.Email,
                FirstName = reg.FirstName,
                LastName = reg.LastName,
                Password = reg.Password
              };
              db.Users.Add(m);
              db.SaveChanges();
              return RedirectToAction("Login");
            }
        }
        return View();
    }
