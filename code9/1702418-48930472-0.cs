    services.AddIdentity<ApplicationUser, IdentityRole>(options=>
    {
        var allowed = options.User.AllowedUserNameCharacters 
                      + "........";
        options.User.AllowedUserNameCharacters = allowed;
    })
