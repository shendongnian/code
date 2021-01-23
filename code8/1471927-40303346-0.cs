    [HttpPost]
    [ActionName("Register")]
    public ActionResult RegisterDo(UserRegistrationViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new Users();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.PasswordSalt = Helpers.PasswordHelper.CreateSalt(40);
            user.PasswordHash = Helpers.PasswordHelper.CreatePasswordHash(model.Password, user.PasswordSalt);
            user.CountryId = Convert.ToInt32(model.SelectedCountryId);
            user.Active = true;
            Connection.ctx.Users.Add(user);
            Connection.ctx.SaveChanges();
            var role = new UserRoles();
            role.RoleId = 2;
            role.UserId = user.UserId;
            role.Active = true;
            user.UserRoles.Add(role);
            Connection.ctx.SaveChanges();
            return RedirectToAction("Success");
        }
        else
        {
            return View(model);
        }
    }
