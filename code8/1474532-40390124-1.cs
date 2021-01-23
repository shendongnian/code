    var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
    if (result.Succeeded)
    {
    	//Get Steam User
    	if(info.LoginProvider.ToLower() == "steam")
    	{
    		var user = await _userManager.FindByLoginAsync("Steam", info.ProviderKey);
    		user.AvatarPath = SteamApi.GetSteamAvatar(playerData);
    		var ir = await _userManager.UpdateAsync(user);
    		if(!ir.Succeeded)
    		{
    			foreach (var err in ir.Errors)
    			{
    				Console.WriteLine(err.Code + " - " + err.Description);
    			}
    		}
    	}
    }
