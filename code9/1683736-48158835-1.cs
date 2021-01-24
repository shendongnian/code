    var isPublicClient = User.HasClaim("scope", "PublicClient");
    if (isPublicClient)
        return new UserViewModel { Name = "my name", Address = "my address" };
    else
        return new UserViewModel { Name = "my name", Address = "my address", SuperSecretNoOneCanSee = "secret" };
