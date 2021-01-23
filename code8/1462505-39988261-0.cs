    public async Task ChangePassword()
    {
        var currentUser = await _userManager.FindByEmailAsync("test@theworld.com") 
        if (currentUser != null)
        {
            _userManager.RemovePasswordAsync(currentUser.Id);
            _userManager.AddPasswordAsync(currentUser.Id, "newPassword");
        }
    }
