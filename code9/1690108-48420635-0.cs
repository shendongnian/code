    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditUserData(ApplicationUser user)
    {
            ApplicationUser model = db.Users.Find(User.Identity.GetUserId());
            model.Email = user.Email; 
			model.UserName = user.UserName; 
			model.FullName = user.FullName; 
			model.Website = user.Website;
            IdentityResult result = await Usermanager.UpdateAsync(model);
            return RedirectToAction("Settings","Admin");
    }
