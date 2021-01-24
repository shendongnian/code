    options.Tokens.PasswordResetTokenProvider = _defaultTokenProviderName;
    
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = false;
    
                    options.User.RequireUniqueEmail = true;
    
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_.";
    
                    options.SecurityStampValidationInterval = TimeSpan.Zero;
    
    
    
                    options.Cookies.ApplicationCookie.CookieName = "Identity_cookie";
                    options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromHours(1);
                    options.Cookies.ApplicationCookie.SlidingExpiration = true;
