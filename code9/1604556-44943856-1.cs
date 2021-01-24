        [HttpPost]
        public ActionResult Register(User user)
        {
          ViewBag.LoggedIn = false;
          if(!this.ModelState.IsValid)
          {
             return View(user);
             //this will render a view with preserved invalid model state so all the values with the corresponding error messages will be shown.
          }
          user.Password = PasswordHash.CreateHash(user.Password);
          using (var context = new FoundationContext())
          {
              // if user exists
              if (context.Users.FirstOrDefault(n => n.Email == user.Email) != null) return Login(true);
              context.Users.Add(user);
              context.SaveChanges();
          }
          return RedirectToAction("Index", "Home");
        }
