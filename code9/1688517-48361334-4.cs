    foreach (var toRegister in model.ApplicationUsers)
    {
        var hasher = _userManager.PasswordHasher;
        var user = new ApplicationUser {UserName = toRegister.UserName, Email = toRegister.Password};
        toRegister.Hashed = hasher.HashPassword(user, toRegister.Password);
    }
