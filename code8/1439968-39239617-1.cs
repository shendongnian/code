    var user = UserManager.FindById(form["AspNetUserID"]);
    user.LockoutEnabled = true;
    user.LockoutEndDateUtc = DateTime.UtcNow.AddYears(100)};
    var result = await manager.UpdateAsync(user);
    if (result.Succeeded)
    {
        //success
    }
    else
    {
        //something went wrong
    }
