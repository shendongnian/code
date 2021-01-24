    [HttpGet]
	public async Task<IActionResult> UserSelfDelete()
	{
	    var user = await _userManager.GetUserAsync(User);
		if (user == null)
		{
			throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
		}
		// Validate business rules to ensure self-deletion is allowed, though it would
		// be a good idea to tell the user why their account cannot be deleted
		var userSelfDelete = new UserSelfDeleteViewModel
		{
			Email = user.Email,
			UserName = user.UserName
		};
		return View(userSelfDelete);
	}
    [HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> UserSelfDelete(UserSelfDeleteViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}
		var user = await _userManager.GetUserAsync(User);
		if (user == null)
		{
		    throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
		}
		if (await _userManager.CheckPasswordAsync(user, model.Password) == false)
		{
			ModelState.AddModelError("Password", "Incorrect password entered");
			return View(model);
		}
		await _signInManager.SignOutAsync();
		_logger.LogInformation("User logged out prior to account deletion.");
		await _userManager.DeleteAsync(user);
		return RedirectToAction(nameof(HomeController.Index), "Home");
	}
