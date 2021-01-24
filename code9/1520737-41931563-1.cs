    [HttpPost]
	public async Task<ActionResult> SetNames(SetUserFullNamesViewModel model)
	{
		ApplicationUser usermodel = UserManager.FindById(user.Id);
		usermodel.Name = model.Name;
		usermodel.Surname = model.Surname;
		IdentityResult result = await UserManager.UpdateAsync(usermodel);
		if (result.Succeeded)
		{
			return RedirectToAction("ListUser", "User");
		}
		return View();
	}
