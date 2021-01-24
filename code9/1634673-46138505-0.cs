	var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
	if (result.Succeeded)
	{
		_logger.LogInformation("User logged in.");
		var user = _context.Users.Single(x => x.Email == model.Email);
		if(user.EmailConfirmed)
		{
			return View("~/Views/Task/Index.cshtml");
		}
		else
		{
			return View("ConfirmEmail");
		}
		
	}
