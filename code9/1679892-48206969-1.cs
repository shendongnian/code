    Provider = new CookieAuthenticationProvider
              {
                 OnValidateIdentity =  SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                            validateInterval: TimeSpan.FromMinutes(30),
                            regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
              },
              SlidingExpiration = false,
              ExpireTimeSpan = TimeSpan.FromMinutes(15)
