    //...other code removed for brevity
    var user = new User { UserName = model.Email, Email = model.Email, RegisterDate = DateTime.Now };
    var result = await UserManager.CreateAsync(user, model.Password);
    if (result.Succeeded)
    {
        //pick one
        //user = await UserManager.FindById(model.Id);
        //user = await UserManager.FindByName(model.UserName);
        user = await UserManager.FindByEmailAsync(model.Email);
        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        await SendConfirmationEmail(user);
        return View("ConfirmationEmailSent");
    }
    AddErrors(result);
