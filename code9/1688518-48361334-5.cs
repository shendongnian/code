    [HttpPost]
    public async Task<IActionResult> RegisterLotsOfPeople(RegisterLotsModel model)
    {
        var successful = new List<string>();
        var failed = new List<string>();
        foreach (var toRegister in model.ApplicationUsers)
        {
            var user = new ApplicationUser {UserName = toRegister.UserName, Email = toRegister.Password};
            var result = await _userManager.CreateAsync(user, toRegister.Password);
            if (result.Succeeded)
            {
                successful.Add(toRegister.UserName);
            }
            else
            {
                failed.Add(toRegister.UserName);
            }
        }
        return Json(new {SuccessfullyRegistered = successful, FailedToRegister = failed});
    }
