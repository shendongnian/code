    //...
    var user = await UserManager.FindByEmailAsync(model.Email);
    if (user != null) {
        if (!await UserManager.IsEmailConfirmedAsync(user.Id)) {
            ViewBag.errorMessage = "You must have a confirmed email to log on.";
            return View("Error");
        }
    }
    var result = await SignInManager.PasswordSignInAsync(user.Username, model.Password, model.RememberMe, shouldLockout: false);
    //...
