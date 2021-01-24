    public virtual async Task<bool> CanSignInAsync(TUser user)
            {
                if (Options.SignIn.RequireConfirmedEmail && !(await UserManager.IsEmailConfirmedAsync(user)))
                {
                    Logger.LogWarning(0, "User {userId} cannot sign in without a confirmed email.", await UserManager.GetUserIdAsync(user));
                    return false;
                }
                if (Options.SignIn.RequireConfirmedPhoneNumber && !(await UserManager.IsPhoneNumberConfirmedAsync(user)))
                {
                    Logger.LogWarning(1, "User {userId} cannot sign in without a confirmed phone number.", await UserManager.GetUserIdAsync(user));
                    return false;
                }
    
                return true;
    }
