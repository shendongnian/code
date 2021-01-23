    [HttpPost]
    public ActionResult Register(UserVIewModel reg) {
        if (!ModelState.IsValid)
        {
			 return View(model);
		}
		
        // here is the main answer to your question
		bool userExists = db.Users.FirstOrDefault(x => x.UserName == reg.UserName) != null;
		// and then use the bool to see if you need to return an error
        if (userExists) { 
			// I'm not 100% sure about this part so double-check this
            // but I think it's pretty close to this
			ModelState.AddModelError("UserName","UserName taken");
			return View(model);
		}
		
		
		// If the userExists = false then code continues here
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
