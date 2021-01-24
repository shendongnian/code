        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                ViewBag.LoggedIn = false;
                user.Password = PasswordHash.CreateHash(user.Password);
                using (var context = new FoundationContext())
                {
                    // if user exists
                    if (context.Users.FirstOrDefault(n => n.Email == user.Email) != null) return Login(true);
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                return View("~/Views/Home.Index.cshtml");
            }
            return View(user);
        }
