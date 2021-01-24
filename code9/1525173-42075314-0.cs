    // Require the user to have a confirmed email before they can log on.
    var user = await UserManager.FindByNameAsync(model.Email);
    if (user != null)
    {
       if (!await UserManager.IsEmailConfirmedAsync(user.Id))
       {
          ViewBag.errorMessage = "You must have a confirmed email to log on.";
          return View("Error");
       }
    }
