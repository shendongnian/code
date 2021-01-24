    public virtual async Task<bool> CanSignInAsync(TUser user)
    {
        if (Options.SignIn.RequireConfirmedEmail &&
            !(await UserManager.IsEmailConfirmedAsync(user)))
        {
            return false;
        }
    
        if (Options.SignIn.RequireConfirmedPhoneNumber &&
            !(await UserManager.IsPhoneNumberConfirmedAsync(user)))
        {
            return false;
        }
        return true;
    }
