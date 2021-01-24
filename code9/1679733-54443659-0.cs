     services.AddIdentity<User, Role>(
                    options =>
                    {                        
                        options.User.AllowedUserNameCharacters = string.Empty;
                    })
