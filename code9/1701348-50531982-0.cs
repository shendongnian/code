    static async Task<IdentityResult> UpdateEmailAsync<TUser>(
        IPrincipal principal,
        UserManager<TUser, string> userManager,
        SignInManager<TUser, string> signInManager,
        string newEmail
    )
        where TUser : class, IUser<string>
    {
        string userId = principal.Identity.GetUserId();
        IdentityResult result = await userManager.SetEmailAsync(userId, newEmail);
        if (result.Succeeded)
        {
            // automatically confirm user's email
            string confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(userId);
            result = await userManager.ConfirmEmailAsync(userId, confirmationToken);
            if (result.Succeeded)
            {
                TUser user = await userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    // update username
                    user.UserName = newEmail;
                    await userManager.UpdateAsync(user);
                    // creates new identity with updated user's name
                    await signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                // succeded
                return result;
            }
        }
        // failed
        return result;
    }
