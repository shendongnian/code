    ApplicationUser user = await UserManager.FindByEmailAsync(model.Email);
    if (UserManager.IsInRole(user.Id, "Users"))
    {
        // Do something.
    }
